using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class CreateGuildPacket : Packet
    {
        public string Name;

        public override PacketType Type => PacketType.CREATEGUILD;

        public override void Read(PacketReader r) => Name = r.ReadString();

        public override void Write(PacketWriter w) => w.Write(Name);
    }
}
