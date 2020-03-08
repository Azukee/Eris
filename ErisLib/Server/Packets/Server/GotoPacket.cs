using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class GotoPacket : Packet
    {
        public int ObjectId;
        public Location Location;
        public override PacketType Type => PacketType.GOTO;

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            Location = new Location().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            Location.Write(w);
        }
    }
}