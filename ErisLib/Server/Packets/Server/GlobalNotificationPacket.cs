using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class GlobalNotificationPacket : Packet
    {
        public int NotificationType;
        public string Text;
        
        public override PacketType Type => PacketType.GLOBALNOTIFICATION;

        public override void Read(PacketReader r)
        {
            NotificationType = r.ReadInt32();
            Text = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(NotificationType);
            w.Write("Welcome to Eris");
        }
    }
}