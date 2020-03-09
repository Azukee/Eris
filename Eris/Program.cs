using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using ErisLib;
using ErisLib.Interfaces;

namespace Eris
{
    internal class Program
    {
        private static Proxy proxy;
        
        private static Dictionary<string, IPlugin> _pluginNameMap = new Dictionary<string, IPlugin>();

        [STAThread]
        public static void Main(string[] args)
        {
            Console.Title = "Eris";
            proxy = new Proxy(true);
            InitPlugins();
            
            Console.WriteLine("Attempting to start proxy...");
            
            proxy.Start();

            Console.ReadKey();
        }

        public static void InitPlugins()
        {
            string pDir = Directory.GetCurrentDirectory() + @"\Plugins\";

            if (!Directory.Exists(pDir)) {
                Directory.CreateDirectory(pDir);
                return;
            }

            foreach (string pPath in Directory.GetFiles(pDir, "*.dll", SearchOption.AllDirectories)) {
                if (new FileInfo(pPath).Name.Contains("ErisLib")) continue;
                Assembly pAssembly = Assembly.LoadFrom(pPath);

                foreach (Type pType in pAssembly.GetTypes()) {
                    if (!pType.IsPublic || pType.IsAbstract) continue;
                    try {

                        if (pType.GetInterface("ErisLib.Interfaces.IPlugin") != null)
                            AttachPlugin(pType);
                    }
                    catch (Exception e) {
                        // ignored
                    }
                }
            }
        }

        private static void AttachPlugin(Type type)
        {
            IPlugin instance = (IPlugin)Activator.CreateInstance(type);
            string name = instance.Name();
            instance.Initialize(proxy);

            _pluginNameMap.Add(name, instance);

            Console.WriteLine("Loaded and attached {0}.", name);
        }
    }
}