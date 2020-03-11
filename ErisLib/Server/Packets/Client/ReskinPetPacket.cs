using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ReskinPetPacket : Packet
    {
        public int PetId;
		public int NewPetType;
		public Slot Item;

        public override PacketType Type => PacketType.RESKINPET;

        public override void Read(PacketReader r)
        {
            PetId = r.ReadInt32();
			NewPetType = r.ReadInt32();
			Item = new Slot().Read(r);
		}

        public override void Write(PacketWriter w)
        {
            w.Write(PetId);
			w.Write(NewPetType);
			Item.Write(w);
        }
    }
}
