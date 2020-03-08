using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class UsePortalPacket : Packet
    {
        public int ObjectId;

        public override PacketType Type => PacketType.USEPORTAL;

        public override void Read(PacketReader r) => ObjectId = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(ObjectId);
    }
}