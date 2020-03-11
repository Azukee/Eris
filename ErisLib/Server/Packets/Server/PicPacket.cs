using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class PicPacket : Packet
    {
        public Bitmap BitmapData;

        public override PacketType Type => PacketType.PIC;

        public override void Read(PacketReader r) => BitmapData = BitmapData.Read(r);

        public override void Write(PacketWriter w) => BitmapData.Write(w);
    }
}
