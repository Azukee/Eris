using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class UseItemPacket : Packet
    {
        public int Time;
        public Slot SlotObject;
        public Location ItemUsePos;
        public byte UseType;

        public override PacketType Type => PacketType.USEITEM;

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            SlotObject = new Slot().Read(r);
            ItemUsePos = new Location().Read(r);
            UseType = r.ReadByte();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            SlotObject.Write(w);
            ItemUsePos.Write(w);
            w.Write(UseType);
        }
    }
}