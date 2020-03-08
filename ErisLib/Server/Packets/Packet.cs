using System;
using System.IO;
using ErisLib.Game;
using ErisLib.Game.Packets;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets
{
    public class Packet
    {
        public bool Send = true;
        public int PacketSize;
        public byte Id;
        private static byte[] _data;
        public virtual PacketType Type => PacketType.UNKNOWN;
        
        public virtual void Read(PacketReader r)
        {
            _data = r.ReadBytes((int)r.BaseStream.Length - 5); // All of the packet data
        }
        
        public virtual void Write(PacketWriter w)
        {
            w.Write(_data); // All of the packet data
        }
        
        public static Packet Construct(byte[] rawData)
        {
            using (PacketReader r = new PacketReader(new MemoryStream(rawData))) {
                int packetSize = r.ReadInt32();
                byte packetID = r.ReadByte();
                Console.WriteLine(packetID);

                PacketStructure st = Constants.GameData.Packets.ByID(packetID);
                PacketType pType = st.PacketType;
                Type type = st.Type; 
                Packet packet = (Packet)Activator.CreateInstance(type);
                packet.PacketSize = packetSize;
                
                packet.Read(r);
                return packet;
            }
        }
    }
}