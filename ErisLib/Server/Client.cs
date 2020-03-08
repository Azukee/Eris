using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using ErisLib.Cryptography;
using ErisLib.Server.Packets;
using ErisLib.Server.Packets.Client;
using ErisLib.Server.StateHandler;

namespace ErisLib.Server
{
    public class Client
    {
        private const string OutgoingKey = "6a39570cc9de4ec71d64821894";
        private const string IncomingKey = "c79332b197f92ba85ed281a023";

        private bool _closed = false;
        
        private Proxy _proxy;
        private TcpClient _tcpClient;
        private TcpClient _serverClient;
        
        private NetworkStream _clientStream;
        private NetworkStream _serverStream;
        
        private CustomBuffer _clientBuffer = new CustomBuffer();
        private CustomBuffer _serverBuffer = new CustomBuffer();
        
        private object _serverLock = new object();
        private object _clientLock = new object();
        
        private RC4 _clientRecvCipher = new RC4(OutgoingKey);
        private RC4 _serverRecvCipher = new RC4(IncomingKey);
        private RC4 _clientSendCipher = new RC4(IncomingKey);
        private RC4 _serverSendCipher = new RC4(OutgoingKey);

        public State State { get; set; }

        public Client(Proxy proxy, TcpClient tcpClient)
        {
            _proxy = proxy;
            _tcpClient = tcpClient;
            _clientStream = _tcpClient.GetStream();
            _tcpClient.NoDelay = true;
            Read(0, 4, true);
        }

        public void Connect(HelloPacket state)
        {
            _serverClient = new TcpClient {NoDelay = true};
            _serverClient.BeginConnect(State.ConTargetAddress, State.ConTargetPort, ServerConnected, state);
        }
        
        private void ServerConnected(IAsyncResult ar)
        {
            _serverClient.EndConnect(ar);
            _serverStream = _serverClient.GetStream();
            Console.WriteLine("Connection successful");
            
            Send(ar.AsyncState as Packet, false);
            Read(0, 4, false);
        }
        
        private void Read(int offset, int count, bool isClient)
        {
            CustomBuffer cb = isClient ? _clientBuffer : _serverBuffer;
            NetworkStream ns = isClient ? _clientStream : _serverStream;
            try { 
                ns.BeginRead(cb.Buffer, offset, count, ReadCallback, (ns, cb));}
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Dispose();
            }
        }

        public void Dispose()
        {
            if (!_closed)
            {
                _closed = true;
                _clientStream?.Close();
                _serverStream?.Close();
                _tcpClient?.Close();
                _serverClient?.Close();
                _clientBuffer.Dispose();
                _serverBuffer.Dispose();
            }
        }
        
        private void Send(Packet packet, bool client)
        {
            lock (client ? _clientLock : _serverLock)
            {
                MemoryStream ms = new MemoryStream();
                using (PacketWriter w = new PacketWriter(ms))
                {
                    w.Write(packet.PacketSize);
                    w.Write(packet.Id);
                    packet.Write(w);
                }

                byte[] data = ms.ToArray();
                PacketWriter.BlockCopyInt32(data, data.Length);

                if (client)
                {
                    Console.WriteLine($"Sent {packet.Type} to the client");
                    _clientSendCipher.Cipher(data);
                    _clientStream.Write(data, 0, data.Length);
                }
                else
                {
                    Console.WriteLine($"Sent {packet.Type} to the server");
                    _serverSendCipher.Cipher(data);
                    _serverStream.Write(data, 0, data.Length);
                }
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            CustomBuffer cb = (ar.AsyncState as (NetworkStream _ns, CustomBuffer _cb)? ?? (null, null))._cb;
            NetworkStream ns = (ar.AsyncState as (NetworkStream _ns, CustomBuffer _cb)? ?? (null, null))._ns;
            bool isClient = ns == _clientStream;
            RC4 currCipher = isClient ? _clientRecvCipher : _serverRecvCipher;

            if (!ns.CanRead) return;

            int read = ns.EndRead(ar);
            cb.Walk(read);

            if (read == 0)
            {
                Dispose();    
            }else if (cb.Idx == 4) {
                cb.ResizeBuffer(IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cb.Buffer, 0)));
                Read(cb.Idx, cb.Remaining, isClient);
            } else if (cb.Remaining > 0) {
                Read(cb.Idx, cb.Remaining, isClient);
            }
            else {
                currCipher.Cipher(cb.Buffer);
                Console.WriteLine("Received Data! Size: " + cb.Buffer.Length);
                
                Packet p = Packet.Construct(cb.Buffer);
                Console.WriteLine("Received Data is a " + p.Type + " packet!");
                
                if (isClient)
                    _proxy.ClientPacketSent(this, p);
                else
                    _proxy.ServerPacketSent(this, p);
                
                if (p.Send)
                    Send(p, !isClient);

                cb.Clear();
                Read(0, 4, isClient);
            }
        }
    }
}