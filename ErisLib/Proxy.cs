using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using ErisLib.Server;

namespace ErisLib
{
    public delegate void ConnectionHandler(Client client);
 
    public class Proxy
    {
        public event ConnectionHandler ClientBeginConnect;
        
        private TcpListener _tcpListener;

        public Proxy()
        {
            //Construct Constants
            Constants.ConstructConstants();
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
        }
    }
}