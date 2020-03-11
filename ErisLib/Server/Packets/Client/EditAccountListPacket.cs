using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class EditAccountListPacket : Packet
    {
        public int AccountListId;
        public bool Add;
        public int ObjectId;

        public override PacketType Type => PacketType.EDITACCOUNTLIST;

        public override void Read(PacketReader r)
        {
            AccountListId = r.ReadInt32();
            Add = r.ReadBoolean();
            ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(AccountListId);
            w.Write(Add);
            w.Write(ObjectId);
        }
    }
}
