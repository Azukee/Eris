namespace ErisLib.Server.Packets.Models
{
    public class Item
    {
        public int ItemItem;
        public int SlotType;
        public bool Tradable;
        public bool Included;

        public Item Read(PacketReader r)
        {
            ItemItem = r.ReadInt32();
            SlotType = r.ReadInt32();
            Tradable = r.ReadBoolean();
            Included = r.ReadBoolean();

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(ItemItem);
            w.Write(SlotType);
            w.Write(Tradable);
            w.Write(Included);
        }
    }
}