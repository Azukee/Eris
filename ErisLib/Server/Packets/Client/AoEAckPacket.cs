using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class AoEAckPacket : Packet
    {
        public int Time;
        public Location Position;

        public override PacketType Type => PacketType.AOEACK;

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            Position = new Location().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            Position.Write(w);
        }
    }
}
