﻿using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class SquareHitPacket : Packet
    {
        public int Time;
        public byte BulletId;
        public int ObjectId;

        public override PacketType Type => PacketType.SQUAREHIT;

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            BulletId = r.ReadByte();
            ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            w.Write(BulletId);
            w.Write(ObjectId);
        }
    }
}
