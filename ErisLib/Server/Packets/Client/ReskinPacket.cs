using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ReskinPacket : Packet
    {
        public int SkinId;

        public override PacketType Type => PacketType.RESKIN;

        public override void Read(PacketReader r)
        {
            SkinId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(SkinId);
        }
    }
}
