using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class PasswordPromptPacket : Packet
    {
		public int CleanPasswordStatus;

        public override PacketType Type => PacketType.PASSWORDPROMPT;

        public override void Read(PacketReader r) => CleanPasswordStatus = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(CleanPasswordStatus);
    }
}
