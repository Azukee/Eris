﻿using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class ArenaDeathPacket : Packet
    {
        public int RestartPrice;

        public override PacketType Type => PacketType.ARENADEATH;

        public override void Read(PacketReader r) => RestartPrice = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(RestartPrice);
    }
}
