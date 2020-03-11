using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
	public class ReskinUnlock : Packet
	{
		public int SkinId;
        public int IsPetSkin;

		public override PacketType Type => PacketType.RESKINUNLOCK;

        public override void Read(PacketReader r)
		{
			SkinId = r.ReadInt32();
            IsPetSkin = r.ReadInt32();
        }

		public override void Write(PacketWriter w)
		{
			w.Write(SkinId);
            w.Write(IsPetSkin);
		}
	}
}
