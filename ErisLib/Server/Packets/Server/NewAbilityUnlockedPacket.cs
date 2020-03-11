using ErisLib.Game;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class NewAbilityUnlockedPacket : Packet
    {
		public Ability AbilityType;

        public override PacketType Type => PacketType.NEWABILITYUNLOCKED;

        public override void Read(PacketReader r) => AbilityType = (Ability)r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write((int)Type);
    }
}
