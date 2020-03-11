using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class QuestRedeemResponsePacket : Packet
    {
        public bool Success;
        public string Message;

        public override PacketType Type => PacketType.QUESTREDEEMRESPONSE;

        public override void Read(PacketReader r)
        {
            Success = r.ReadBoolean();
            Message = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Success);
            w.Write(Message);
        }
    }
}
