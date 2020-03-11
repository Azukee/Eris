using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class CheckCreditsPacket : Packet
    {
        public override PacketType Type => PacketType.CHECKCREDITS;

        public override void Read(PacketReader r)
        { }

        public override void Write(PacketWriter w)
        { }
    }
}
