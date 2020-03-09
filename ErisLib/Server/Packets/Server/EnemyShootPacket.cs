using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class EnemyShootPacket : Packet
    {
        public byte BulletId;
        public int OwnerId;
        public byte BulletType;
        public Location Location;
        public float Angle;
        public short Damage;
        public byte NumShots;
        public float AngleInc;

        public override PacketType Type => PacketType.ENEMYSHOOT;

        public override void Read(PacketReader r)
        {
            BulletId = r.ReadByte();
            OwnerId = r.ReadInt32();
            BulletType = r.ReadByte();
            Location = new Location().Read(r);
            Angle = r.ReadSingle();
            Damage = r.ReadInt16();

            if (r.BaseStream.Position < r.BaseStream.Length) {
                NumShots = r.ReadByte();
                AngleInc = r.ReadSingle();
            } else {
                NumShots = 1;
                AngleInc = 0.0F;
            }
        }

        public override void Write(PacketWriter w)
        {
            w.Write(BulletId);
            w.Write(OwnerId);
            w.Write(BulletType);
            Location.Write(w);
            w.Write(Angle);
            w.Write(Damage);

            if (NumShots != 1) {
                w.Write((byte) NumShots);
                w.Write(AngleInc);
            }
        }
    }
}