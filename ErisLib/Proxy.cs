using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using ErisLib.Server;
using ErisLib.Server.Packets;
using ErisLib.Server.Packets.Client;
using ErisLib.Server.Packets.Models;
using ErisLib.Server.StateHandler;
using ErisLib.Utilities;

namespace ErisLib
{
    public delegate void ConnectionHandler(Client client);
    public delegate void GenericPacketHandler<T>(Client client, T packet) where T : Packet;
    public delegate void CommandHandler(Client client, string command, string[] args);
 
    public class Proxy
    {
        public event ConnectionHandler ClientBeginConnect;
        
        private TcpListener _tcpListener;

        public Dictionary<string, State> States;
        
        private Dictionary<object, Type> _genericPacketHooks;
        private Dictionary<CommandHandler, List<string>> _commandHooks;
        
        public Proxy(bool verbose = false)
        {
            //Construct Constants
            Constants.ConstructConstants(verbose);
            States = new Dictionary<string, State>();
            _genericPacketHooks = new Dictionary<object, Type>();
            _commandHooks = new Dictionary<CommandHandler, List<string>>();
            
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
            Console.WriteLine("--- RECV CLIENT ---");
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
        
        public void HookCommand(string command, CommandHandler callback)
        {
            if (_commandHooks.ContainsKey(callback))
                _commandHooks[callback].Add(command);
            else
                _commandHooks.Add(callback, new List<string>() { command[0] == '/' 
                    ? new string(command.Skip(1).ToArray()).ToLower() 
                    : command.ToLower() } );    
            ConsoleUtilities.TagWriteLine($"Successfully hooked {command} - {callback.Method.DeclaringType?.Name +"."+ callback.Method.Name}", "HOOKS", ConsoleColor.Cyan);

        }
        
        public void HookPacket<T>(GenericPacketHandler<T> callb) where T : Packet
        {
            if (!_genericPacketHooks.ContainsKey(callb)) {
                _genericPacketHooks.Add(callb, typeof(T));
                ConsoleUtilities.TagWriteLine($"Successfully hooked {typeof(T).Name} - {callb.Method.DeclaringType?.Name +"."+ callb.Method.Name}", "HOOKS", ConsoleColor.Cyan);
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
            if (packet.Type == PacketType.PLAYERTEXT) {
                PlayerTextPacket playerText = (PlayerTextPacket)packet;
                string text = playerText.Text.Replace("/", "").ToLower();
                string command = text.Contains(' ')
                    ? text.Split(' ')[0].ToLower()
                    : text;
                string[] args = text.Contains(' ')
                    ? text.Split(' ').Skip(1).ToArray()
                    : new string[0];

                foreach (var pair in _commandHooks)
                    if (pair.Value.Contains(command)) {
                        packet.Send = false;
                        pair.Key(client, command, args);
                    }
            }
            
            foreach (var pair in _genericPacketHooks.Where(pair => pair.Value == packet.GetType())) {
                (pair.Key as Delegate)?.Method.Invoke((pair.Key as Delegate)?.Target, 
                    new object[2] { client, Convert.ChangeType(packet, pair.Value) });
            }
        }
    }
}