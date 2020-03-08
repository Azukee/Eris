using System;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class MapInfoPacket : Packet
    {
        public int Width;
        public int Height;
        public string Name;
        public string DisplayName;
        public string RealmName;
        public int Difficulty;
        public uint Fp;
        public int Background;
        public bool AllowPlayerTeleport;
        public bool ShowDisplays;
        public short MaxPlayers;
        public string ConnectionGuid;
        public string[] ClientXML = new String[0];
        public string[] ExtraXML = new String[0];

        public override PacketType Type => PacketType.MAPINFO;

        public override void Read(PacketReader r)
        {
            Width = r.ReadInt32();
            Height = r.ReadInt32();
            Name = r.ReadString();
            DisplayName = r.ReadString();
            RealmName = r.ReadString();
            Fp = r.ReadUInt32();
            Background = r.ReadInt32();
            Difficulty = r.ReadInt32();
            AllowPlayerTeleport = r.ReadBoolean();
            ShowDisplays = r.ReadBoolean();
            MaxPlayers = r.ReadInt16();
            ConnectionGuid = r.ReadString();

            ClientXML = new string[r.ReadInt16()];
            for (int i = 0; i < ClientXML.Length; i++)
                ClientXML[i] = r.ReadUTF32();

            ExtraXML = new string[r.ReadInt16()];
            for (int i = 0; i < ExtraXML.Length; i++)
                ExtraXML[i] = r.ReadUTF32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Width);
            w.Write(Height);
            w.Write(Name);
            w.Write(DisplayName);
            w.Write(RealmName);
            w.Write(Fp);
            w.Write(Background);
            w.Write(Difficulty);
            w.Write(AllowPlayerTeleport);
            w.Write(ShowDisplays);
            w.Write(MaxPlayers);
            w.Write(ConnectionGuid);
            w.Write((ushort)ClientXML.Length);
            foreach (string i in ClientXML)
                w.WriteUTF32(i);
            w.Write((ushort)ExtraXML.Length);
            foreach (string i in ExtraXML)
                w.WriteUTF32(i);
        }
    }
}