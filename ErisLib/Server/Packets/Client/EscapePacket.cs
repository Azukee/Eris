using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class EscapePacket : Packet
    {
        public override PacketType Type => PacketType.ESCAPE;

        public override void Read(PacketReader r)
        { }

        public override void Write(PacketWriter w)
        { }
    }
}
