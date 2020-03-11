using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class CancelTradePacket : Packet
    {
        public override PacketType Type => PacketType.CANCELTRADE;

        public override void Read(PacketReader r)
        { }

        public override void Write(PacketWriter w)
        { }
    }
}
