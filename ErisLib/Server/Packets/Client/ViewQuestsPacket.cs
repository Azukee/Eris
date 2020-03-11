using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ViewQuestsPacket : Packet
    {
        public override PacketType Type => PacketType.VIEWQUESTS;

        public override void Read(PacketReader r)
        { }

        public override void Write(PacketWriter w)
        { }
    }
}
