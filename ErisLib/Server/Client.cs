using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ErisLib.Cryptography;
using ErisLib.Server.Packets;

namespace ErisLib.Server
{
    public class Client
    {
        private const string OutgoingKey = "6a39570cc9de4ec71d64821894";
        private const string IncomingKey = "c79332b197f92ba85ed281a023";
        
        private Proxy _proxy;
        private TcpClient _tcpClient;
        
        private NetworkStream _clientStream;
        private NetworkStream _serverStream;
        
        private CustomBuffer _clientBuffer = new CustomBuffer();
        private CustomBuffer _serverBuffer = new CustomBuffer();
        
        private RC4 _clientRecvCipher = new RC4(OutgoingKey);
        private RC4 _serverRecvCipher = new RC4(IncomingKey);
        private RC4 _clientSendCipher = new RC4(IncomingKey);
        private RC4 _serverSendCipher = new RC4(OutgoingKey);
        
        public Client(Proxy proxy, TcpClient tcpClient)
        {
            _proxy = proxy;
            _tcpClient = tcpClient;
            _clientStream = _tcpClient.GetStream();
            _tcpClient.NoDelay = true;
            Read(0, 4, true);
        }

        private void Read(int offset, int count, bool isClient)
        {
            CustomBuffer cb = isClient ? _clientBuffer : _serverBuffer;
            NetworkStream ns = isClient ? _clientStream : _serverStream;

            ns.BeginRead(cb.Buffer, offset, count, ReadCallback, (ns, cb));
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

            if (read == 0) return;
            
            if (cb.Idx == 4) {
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
            }
        }
    }
}