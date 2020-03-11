using System.Collections.Generic;
using ErisLib.Game;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class DamagePacket : Packet
    {
        public int TargetId;
        public ConditionEffects Effects;
        public ushort Damage;
        public bool Killed;
        public bool ArmorPiece;
        public byte BulletId;
        public int ObjectId;

        public override PacketType Type => PacketType.DAMAGE;

        public override void Read(PacketReader r)
        {
            TargetId = r.ReadInt32();
            byte c = r.ReadByte();
            Effects = 0;
            for (int i = 0; i < c; i++)
                Effects |= (ConditionEffects)(1 << r.ReadByte());
            Damage = r.ReadUInt16();
            Killed = r.ReadBoolean();
            ArmorPiece = r.ReadBoolean();
            BulletId = r.ReadByte();
            ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(TargetId);
            List<byte> eff = new List<byte>();
            for (byte i = 1; i < 255; i++)
                if ((Effects & (ConditionEffects)(1 << i)) != 0)
                    eff.Add(i);
            w.Write((byte)eff.Count);
            foreach (byte i in eff) w.Write(i);
            w.Write(Damage);
            w.Write(Killed);
            w.Write(ArmorPiece);
            w.Write(BulletId);
            w.Write(ObjectId);
        }
    }
}