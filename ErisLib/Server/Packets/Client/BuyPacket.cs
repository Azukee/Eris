using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class BuyPacket : Packet
    {
        public int ObjectId;
		public int Quantity;

        public override PacketType Type => PacketType.BUY;

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
			Quantity = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
			w.Write(Quantity);
        }
    }
}
