using ErisLib.Game;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class ShowEffectPacket : Packet
    {
        public EffectType EffectType;
        public int TargetId;
        public Location PosA;
        public Location PosB;
        public ARGB Color;
        public float Duration;

        public override PacketType Type => PacketType.SHOWEFFECT;

        public override void Read(PacketReader r)
        {
            EffectType = (EffectType)r.ReadByte();
            TargetId = r.ReadInt32();
            PosA = new Location().Read(r);
            PosB = new Location().Read(r);
            Color = ARGB.Read(r);
            Duration = r.ReadSingle();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((byte)EffectType);
            w.Write(TargetId);
            PosA.Write(w);
            PosB.Write(w);
            Color.Write(w);
            w.Write(Duration);
        }
    }
}