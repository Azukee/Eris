using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ActivePetUpdateRequestPacket : Packet
    {
        public byte CommandType;
        public int InstanceId;
        
        public override PacketType Type => PacketType.ACTIVEPETUPDATEREQUEST;

        public override void Read(PacketReader r)
        {
            CommandType = r.ReadByte();
            InstanceId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(CommandType);
            w.Write(InstanceId);
        }
    }
}