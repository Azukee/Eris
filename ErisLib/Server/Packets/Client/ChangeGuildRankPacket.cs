using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ChangeGuildRankPacket : Packet
    {
        public string Name;
        public int GuildRank;

        public override PacketType Type => PacketType.CHANGEGUILDRANK;

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
            GuildRank = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Name);
            w.Write(GuildRank);
        }
    }
}
