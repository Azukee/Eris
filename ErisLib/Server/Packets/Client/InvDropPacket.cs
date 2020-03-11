using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class InvDropPacket : Packet
    {
        public Slot Slot;

        public override PacketType Type => PacketType.INVDROP;

        public override void Read(PacketReader r) => Slot = new Slot().Read(r);

        public override void Write(PacketWriter w) => Slot.Write(w);
    }
}
