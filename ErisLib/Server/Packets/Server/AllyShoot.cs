using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class AllyShoot : Packet
    {
        public byte BulletId;
        public int OwnerID;
        public int ContainerType;
        public float Angle;
        
        public override PacketType Type => PacketType.ALLYSHOOT;

        public override void Read(PacketReader r)
        {
            BulletId = r.ReadByte();
            OwnerID = r.ReadInt32();
            ContainerType = r.ReadInt16();
            Angle = r.ReadSingle();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(BulletId);
            w.Write(OwnerID);
            w.Write(ContainerType);
            w.Write(Angle);
        }
    }
}