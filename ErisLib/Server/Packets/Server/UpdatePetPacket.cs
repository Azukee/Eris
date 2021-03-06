﻿using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class UpdatePetPacket : Packet
    {
        public int PetId;

        public override PacketType Type => PacketType.UPDATEPET;

        public override void Read(PacketReader r) => PetId = r.ReadInt32();

        public override void Write(PacketWriter w) => w.Write(PetId);
    }
}
