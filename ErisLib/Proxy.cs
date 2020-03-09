using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using ErisLib.Server;
using ErisLib.Server.Packets;
using ErisLib.Server.StateHandler;

namespace ErisLib
{
    public delegate void ConnectionHandler(Client client);
    public delegate void GenericPacketHandler<T>(Client client, T packet) where T : Packet;
 
    public class Proxy
    {
        public event ConnectionHandler ClientBeginConnect;
        
        private TcpListener _tcpListener;

        public Dictionary<string, State> States;
        
        private Dictionary<object, Type> _genericPacketHooks;
        public Proxy()
        {
            //Construct Constants
            Constants.ConstructConstants();
            States = new Dictionary<string, State>();
            _genericPacketHooks = new Dictionary<object, Type>();
            
            new StateManager().Attach(this);
            new Server.ConnectionHandler().Attach(this);
        }

        /// <summary>
        /// Starts a TcpListener on 127.0.0.1:2050
        /// </summary>
        public void Start()
        {
            _tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 2050);
            _tcpListener.Start();
            _tcpListener.BeginAcceptTcpClient(TcpListenerCallback, null);
            Console.WriteLine("TCPListener Started!");
        }

        private void TcpListenerCallback(IAsyncResult ar)
        {
            Console.WriteLine("Callback triggered");
            TcpClient tcpClient = _tcpListener.EndAcceptTcpClient(ar);
            Client client = new Client(this, tcpClient);
            
            ClientBeginConnect?.Invoke(client);
            
            _tcpListener?.BeginAcceptTcpClient(TcpListenerCallback, null);
        }

        public State GetState(Client client, byte[] key)
        {
            string guid = key.Length == 0 ? "n/a" : Encoding.UTF8.GetString(key);

            State newState = new State(client, Guid.NewGuid().ToString("n"));
            States[newState.GUID] = newState;

            if (guid != "n/a")
            {
                State lastState = States[guid];
                newState.ConTargetAddress = lastState.ConTargetAddress;
                newState.ConTargetPort = lastState.ConTargetPort;
                newState.ConRealKey = lastState.ConRealKey;
            }

            return newState;
        }
        
        public void HookPacket<T>(GenericPacketHandler<T> callb) where T : Packet
        {
            if (!_genericPacketHooks.ContainsKey(callb)) {
                _genericPacketHooks.Add(callb, typeof(T));
                Console.WriteLine($"[HOOKS] Successfully hooked {typeof(T).Name} - {callb.Method.DeclaringType?.Name +"."+ callb.Method.Name}");
            } else
                return; //todo: log something here
        }

        public void ServerPacketSent(Client client, Packet packet)
        {
            foreach (var pair in _genericPacketHooks.Where(pair => pair.Value == packet.GetType())) {
                (pair.Key as Delegate)?.Method.Invoke((pair.Key as Delegate)?.Target, 
                    new object[2] { client, Convert.ChangeType(packet, pair.Value) });
            }
        }
        
        public void ClientPacketSent(Client client, Packet packet)
        {
            foreach (var pair in _genericPacketHooks.Where(pair => pair.Value == packet.GetType())) {
                (pair.Key as Delegate)?.Method.Invoke((pair.Key as Delegate)?.Target, 
                    new object[2] { client, Convert.ChangeType(packet, pair.Value) });
            }
        }
    }
}