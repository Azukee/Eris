using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class EnemyHitPacket : Packet
    {
        public int Time;
        public byte BulletId;
        public int TargetId;
        public bool Killed;

        public override PacketType Type => PacketType.ENEMYHIT;

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            BulletId = r.ReadByte();
            TargetId = r.ReadInt32();
            Killed = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            w.Write(BulletId);
            w.Write(TargetId);
            w.Write(Killed);
        }
    }
}