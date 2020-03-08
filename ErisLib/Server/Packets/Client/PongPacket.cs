using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class PongPacket : Packet
    {
        public int Serial;
        public int Time;

        public override PacketType Type => PacketType.PONG;

        public override void Read(PacketReader r)
        {
            Serial = r.ReadInt32();
            Time = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Serial);
            w.Write(Time);
        }
    }
}