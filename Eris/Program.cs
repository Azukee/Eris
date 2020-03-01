using System;
using System.Runtime.Remoting.Proxies;
using ErisLib;

namespace Eris
{
    internal class Program
    {
        private static Proxy proxy;

        [STAThread]
        public static void Main(string[] args)
        {
            proxy = new Proxy();
            
            Console.WriteLine("Attempting to start proxy...");
            
            proxy.Start();


            Console.ReadKey();
        }
    }
}