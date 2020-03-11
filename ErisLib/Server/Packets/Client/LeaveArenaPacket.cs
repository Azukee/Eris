using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class LeaveArenaPacket : Packet
    {
        public int Time;

        public override PacketType Type => PacketType.LEAVEARENA;

        public override void Read(PacketReader r) => Time = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(Time);
    }
}
