using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class FailurePacket : Packet
    {
        public int ErrorId;
        public string ErrorDescription;
        public string ErrorPlace;
        public string ErrorConnectionId;
        
        public override PacketType Type => PacketType.FAILURE;
        
        public override void Read(PacketReader r)
        {
            ErrorId = r.ReadInt32();
            ErrorDescription = r.ReadString();
            ErrorPlace = r.ReadString();
            ErrorConnectionId = r.ReadString();
        }
        
        public override void Write(PacketWriter w)
        {
            w.Write(ErrorId);
            w.Write(ErrorDescription);
            w.Write(ErrorPlace);
            w.Write(ErrorConnectionId);
        }
    }
}