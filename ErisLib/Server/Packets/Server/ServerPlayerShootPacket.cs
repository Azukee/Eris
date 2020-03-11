using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class ServerPlayerShootPacket : Packet
    {
        public byte BulletId;
        public int OwnerId;
        public int ContainerType;
        public Location StartingLoc;
        public float Angle;
        public short Damage;
        public override PacketType Type => PacketType.SERVERPLAYERSHOOT;

        public override void Read(PacketReader r)
        {
            BulletId = r.ReadByte();
            OwnerId = r.ReadInt32();
            ContainerType = r.ReadInt32();
            StartingLoc = (Location) new Location().Read(r);
            Angle = r.ReadSingle();
            Damage = r.ReadInt16();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(BulletId);
            w.Write(OwnerId);
            w.Write(ContainerType);
            StartingLoc.Write(w);
            w.Write(Angle);
            w.Write(Damage);
        }
    }
}
