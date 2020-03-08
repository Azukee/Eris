using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class NotificationPacket : Packet
    {
        public int ObjectId;
        public string Message;
        public int Color;

        public override PacketType Type => PacketType.NOTIFICATION;

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            Message = r.ReadString();
            Color = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            w.Write(Message);
            w.Write(Color);
        }
    }
}