using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ChatHelloPacket : Packet
    {
        public string AccountId;
        public string Token;
        
        public override PacketType Type => PacketType.CHATHELLO;

        public override void Read(PacketReader r)
        {
            AccountId = r.ReadString();
            Token = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(AccountId);
            w.Write(Token);
        }
    }
}