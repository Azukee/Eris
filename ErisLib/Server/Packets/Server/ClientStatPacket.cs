using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class ClientStatPacket : Packet
    {
        public string Name;
        public int Value;

        public override PacketType Type => PacketType.CLIENTSTAT;

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
            Value = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Name);
            w.Write(Value);
        }
    }
}
