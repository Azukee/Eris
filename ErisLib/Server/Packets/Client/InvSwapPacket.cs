using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class InvSwapPacket : Packet
    {
        public int Time;
        public Location Position;
        public Slot Slot1;
        public Slot Slot2;
        
        public override PacketType Type => PacketType.INVSWAP;

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            Position = new Location().Read(r);
            Slot1 = new Slot().Read(r);
            Slot2 = new Slot().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            Position.Write(w);
            Slot1.Write(w);
            Slot2.Write(w);
        }
    }
}