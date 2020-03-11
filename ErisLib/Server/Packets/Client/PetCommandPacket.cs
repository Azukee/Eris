using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class PetCommandPacket : Packet
    {
        public int CommandId;
        public uint PetId;

        public override PacketType Type => PacketType.PETCOMMAND;

        public override void Read(PacketReader r)
        {
            CommandId = (int)r.ReadByte();
            PetId = (uint)r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((byte)CommandId);
            w.Write((int)PetId);
        }
    }
}
