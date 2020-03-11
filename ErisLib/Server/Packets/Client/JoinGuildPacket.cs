using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class JoinGuildPacket : Packet
    {
        public string GuildName;

        public override PacketType Type => PacketType.JOINGUILD;

        public override void Read(PacketReader r) => GuildName = r.ReadString();

        public override void Write(PacketWriter w) => w.Write(GuildName);
    }
}
