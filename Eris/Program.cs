using System;
using ErisLib;

namespace Eris
{
    internal class Program
    {
        private static Proxy proxy;

        [STAThread]
        public static void Main(string[] args)
        {
            Console.Title = "Eris";
            proxy = new Proxy(true);
            
            Console.WriteLine("Attempting to start proxy...");
            
            proxy.Start();

            Console.ReadKey();
        }
    }
}