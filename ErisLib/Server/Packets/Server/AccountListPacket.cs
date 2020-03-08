using System.Collections.Generic;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class AccountListPacket : Packet
    {
        public int AccountListID;
        public List<string> AccountIds = new List<string>();
        public int LockAction = -1;
        
        public override PacketType Type => PacketType.ACCOUNTLIST;

        public override void Read(PacketReader r)
        {
            AccountListID = r.ReadInt32();
            int length = r.ReadInt16();
            for(int i = 0; i < length; i++)
                AccountIds.Add(r.ReadString());
            LockAction = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(AccountListID);
            w.Write(AccountIds.Count);
            foreach(string s in AccountIds)
                w.Write(s);
            w.Write(LockAction);
        }
    }
}