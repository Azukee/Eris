using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class HelloPacket : Packet
    {
        public override PacketType Type => PacketType.HELLO;
    }
}