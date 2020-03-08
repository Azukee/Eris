using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class CreateSuccessPacket : Packet
    {
        public int ObjectId;
        public int CharId;
        
        public override PacketType Type => PacketType.LOAD;

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            CharId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            w.Write(CharId);
        }
    }
}