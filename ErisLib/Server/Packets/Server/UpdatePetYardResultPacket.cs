using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class UpdatePetYardResultPacket : Packet
    {
        public int TypeId;

        public override PacketType Type => PacketType.UPGRADEPETYARDRESULT;

        public override void Read(PacketReader r) => TypeId = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(TypeId);
    }
}
