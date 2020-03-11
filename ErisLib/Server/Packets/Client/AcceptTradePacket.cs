﻿using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class AcceptTradePacket : Packet
    {
        public bool[] MyOffers;
        public bool[] YourOffers;

        public override PacketType Type => PacketType.ACCEPTTRADE;

        public override void Read(PacketReader r)
        {
            MyOffers = new bool[r.ReadInt16()];
            for (int i = 0; i < MyOffers.Length; i++)
                MyOffers[i] = r.ReadBoolean();

            YourOffers = new bool[r.ReadInt16()];
            for (int i = 0; i < YourOffers.Length; i++)
                YourOffers[i] = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((ushort)MyOffers.Length);
            foreach (bool i in MyOffers)
                w.Write(i);
            w.Write((ushort)YourOffers.Length);
            foreach (bool i in YourOffers)
                w.Write(i);
        }
    }
}
