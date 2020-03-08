using System;
using System.IO;
using System.Net;
using System.Text;

namespace ErisLib.Server.Packets
{
    public class PacketReader : BinaryReader
    {
        public PacketReader(MemoryStream input)
            : base(input, Encoding.UTF8) { }

        public override short ReadInt16()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt16());
        }

        public override ushort ReadUInt16()
        {
            return (ushort)IPAddress.NetworkToHostOrder((short)base.ReadUInt16());
        }

        public override int ReadInt32()
        {
            return IPAddress.NetworkToHostOrder(base.ReadInt32());
        }

        public override float ReadSingle()
        {
            byte[] arr = base.ReadBytes(4);
            Array.Reverse(arr);
            return BitConverter.ToSingle(arr, 0);
        }

        public override string ReadString()
        {
            return Encoding.UTF8.GetString(ReadBytes(ReadInt16()));
        }

        public string ReadUTF32()
        {
            return Encoding.UTF8.GetString(ReadBytes(ReadInt32()));
        }
    }
}