using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class PetYardCommandPacket : Packet
    {
        public const int UPGRADE_PET_YARD = 1;
        public const int FEED_PET = 2;
        public const int FUSE_PET = 3;

        public byte CommandId;
        public int PetId1;
        public int PetId2;
        public int ObjectId;
        public Slot ObjectSlot;
        public byte Currency;

        public override PacketType Type => PacketType.PETYARDCOMMAND;

        public override void Read(PacketReader r)
        {
            CommandId = r.ReadByte();
            PetId1 = r.ReadInt32();
            PetId2 = r.ReadInt32();
            ObjectId = r.ReadInt32();
            ObjectSlot = new Slot().Read(r);
            Currency = r.ReadByte();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(CommandId);
            w.Write(PetId1);
            w.Write(PetId2);
            w.Write(ObjectId);
            ObjectSlot.Write(w);
            w.Write((byte)Currency);
        }
    }
}
