using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class TradeStartPacket : Packet
    {
        public Item[] MyItems;
        public string YourName;
        public Item[] YourItems;

        public override PacketType Type => PacketType.TRADESTART;

        public override void Read(PacketReader r)
        {
            MyItems = new Item[r.ReadInt16()];
            for (int i = 0; i < MyItems.Length; i++)
                MyItems[i] = new Item().Read(r);

            YourName = r.ReadString();
            YourItems = new Item[r.ReadInt16()];
            for (int i = 0; i < YourItems.Length; i++)
                YourItems[i] = new Item().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write((ushort)MyItems.Length);
            foreach (Item i in MyItems)
                i.Write(w);

            w.Write(YourName);
            w.Write((ushort)YourItems.Length);
            foreach (Item i in YourItems)
                i.Write(w);
        }
    }
}
