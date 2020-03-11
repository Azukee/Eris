using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class VerifyEmailDialogPacket : Packet
    {
        public override PacketType Type => PacketType.VERIFYEMAILDIALOG;

        public override void Read(PacketReader r)
        { }

        public override void Write(PacketWriter w)
        { }
    }
}
