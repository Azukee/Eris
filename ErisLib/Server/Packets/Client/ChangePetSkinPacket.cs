using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class ChangePetSkinPacket : Packet
    {
        public int PetId;
        public int SkinType;
        public int Currency;
        
        public override PacketType Type => PacketType.PETCHANGESKINMSG;

        public override void Read(PacketReader r)
        {
            PetId = r.ReadInt32();
            SkinType = r.ReadInt32();
            Currency = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(PetId);
            w.Write(SkinType);
            w.Write(Currency);
        }
    }
}