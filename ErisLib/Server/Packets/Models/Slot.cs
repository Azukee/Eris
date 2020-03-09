namespace ErisLib.Server.Packets.Models
{
    public class Slot
    {
        public int ObjectId;
        public byte SlotId;
        public int ObjectType;

        public Slot Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            SlotId = r.ReadByte();
            ObjectType = r.ReadInt32();

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            w.Write(SlotId);
            w.Write(ObjectType);
        }
    }
}