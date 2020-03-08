namespace ErisLib.Server.Packets.Models
{
    public class Tile
    {
        public short X;
        public short Y;
        public ushort Type;

        public Tile Read(PacketReader r)
        {
            X = r.ReadInt16();
            Y = r.ReadInt16();
            Type = r.ReadUInt16();

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(X);
            w.Write(Y);
            w.Write(Type);
        }
    }
}