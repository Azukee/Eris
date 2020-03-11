using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class PetEvolveResultPacket : Packet
    {
        public int PetId;
        public int InitialSkin;
        public int FinalSkin;
        public override PacketType Type => PacketType.EVOLVEPET;

        public override void Read(PacketReader r)
        {
            PetId = r.ReadInt32();
            InitialSkin = r.ReadInt32();
            FinalSkin = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(PetId);
            w.Write(InitialSkin);
            w.Write(FinalSkin);
        }
    }
}