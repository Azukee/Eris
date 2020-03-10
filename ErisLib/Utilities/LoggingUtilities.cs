using System.Collections.Generic;
using System.IO;
using ErisLib.Server.Packets;

namespace ErisLib.Utilities
{
    public class LoggingUtilities
    {
        public static void LogPacketToFile(Packet p, bool isClient)
        {
            using (StreamWriter writer = new StreamWriter("debug.txt", true)) {
                string s = "Sent to: " + (isClient ? "client" : "server") + "\r\n";
                writer.Write(s);
                writer.Write(p.ToString());
                writer.Write("\r\n");
            }
        }

        public class PacketModel
        {
            public string Name;
            public int Id;
        
            /// <remarks>Dynamic because it will hold fields of all types. Probably need a soft JSON wrapper for this dunno</remarks>
            public List<(string, dynamic)> Fields = new List<(string, dynamic)>();
        }
    }
}