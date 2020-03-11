using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
	public class KeyInfoResponsePacket : Packet
    {
        public string Name;
        public string Description;
        public string Creator;

		public override PacketType Type => PacketType.KEYINFORESPONSE;

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
            Description = r.ReadString();
            Creator = r.ReadString();
        }

		public override void Write(PacketWriter w)
		{
			w.Write(Name);
            w.Write(Description);
            w.Write(Creator);
		}
	}
}
