using System;
using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    public class HelloPacket : Packet
    {
        public string BuildVersion;
        public int GameId;
        public string GUID;
        public int Random1;
        public string Password;
        public int Random2;
        public string Secret;
        public int KeyTime;
        public byte[] Key;
        public string MapJSON;
        public string EntryTag;
        public string GameNet;
        public string GameNetUserId;
        public string PlayPlatform;
        public string PlatformToken;
        public string UserToken;
        public string Secret2;
        public string PreviousConnectionGuid;

        public override PacketType Type => PacketType.HELLO;

        public override void Read(PacketReader r)
        {
            BuildVersion = r.ReadString();
            GameId = r.ReadInt32();
            GUID = r.ReadString();
            Random1 = r.ReadInt32();
            Password = r.ReadString();
            Random2 = r.ReadInt32();
            Secret = r.ReadString();
            KeyTime = r.ReadInt32();
            short length = r.ReadInt16();
            Key = r.ReadBytes(length);
            MapJSON = r.ReadUTF32();
            EntryTag = r.ReadString();
            GameNet = r.ReadString();
            GameNetUserId = r.ReadString();
            PlayPlatform = r.ReadString();
            PlatformToken = r.ReadString();
            UserToken = r.ReadString();
            Secret2 = r.ReadString();
            PreviousConnectionGuid = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(BuildVersion);
            w.Write(GameId);
            w.Write(GUID);
            w.Write(Random1);
            w.Write(Password);
            w.Write(Random2);
            w.Write(Secret);
            w.Write(KeyTime);
            w.Write((short)Key.Length);
            w.Write((byte[])Key);
            w.WriteUTF32(MapJSON);
            w.Write(EntryTag);
            w.Write(GameNet);
            w.Write(GameNetUserId);
            w.Write(PlayPlatform);
            w.Write(PlatformToken);
            w.Write(UserToken);
            w.Write(Secret2);
            w.Write(PreviousConnectionGuid);
        }

        public void Pipe()
        {
            
        }
    }
}