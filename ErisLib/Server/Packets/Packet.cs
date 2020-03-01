using System;
using System.IO;
using ErisLib.Game;
using ErisLib.Game.Packets;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets
{
    public class Packet
    {
        public int PacketSize;
        public virtual PacketType Type => PacketType.UNKNOWN;
        
        public static Packet Construct(byte[] rawData)
        {
            using (BinaryReader r = new BinaryReader(new MemoryStream(rawData))) {
                int packetSize = r.ReadInt32();
                byte packetID = r.ReadByte();

                PacketStructure st = Constants.GameData.Packets.ByID(packetID);
                PacketType pType = st.PacketType;
                Type type = st.Type; 
                Packet packet = (Packet)Activator.CreateInstance(type);
                packet.PacketSize = packetSize;
                return packet;
            }
        }
    }
}