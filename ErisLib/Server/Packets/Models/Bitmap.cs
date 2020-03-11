namespace ErisLib.Server.Packets.Models
{
    public class Bitmap
    {
        public int Width;
        public int Height;
        public byte[] Bytes = new byte[0];

        public Bitmap Read(PacketReader r)
        {
            Width = r.ReadInt32();
            Height = r.ReadInt32();
            Bytes = new byte[Width * Height * 4];
            Bytes = r.ReadBytes(Bytes.Length);

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(Width);
            w.Write(Height);
            w.Write(Bytes);
        }
    }
}