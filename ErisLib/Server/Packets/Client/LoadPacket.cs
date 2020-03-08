using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class LoadPacket : Packet
    {
        public int CharId;
        public bool IsFromArena;
        public bool IsChallenger;
        
        public override PacketType Type => PacketType.LOAD;

        public override void Read(PacketReader r)
        {
            CharId = r.ReadInt32();
            IsFromArena = r.ReadBoolean();
            IsChallenger = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(CharId);
            w.Write(IsFromArena);
            w.Write(IsChallenger);
        }
    }
}