using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class HatchEggPacket : Packet
    {
        public string PetName;
        public int PetSkinId;
        public override PacketType Type => PacketType.HATCHEGG;

        public override void Read(PacketReader r)
        {
            PetName = r.ReadString();
            PetSkinId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(PetName);
            w.Write(PetSkinId);
        }
    }
}
