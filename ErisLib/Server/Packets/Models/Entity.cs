namespace ErisLib.Server.Packets.Models
{
    public class Entity
    {
        public int ObjectType;
        public Status Status = new Status();

        public Entity Read(PacketReader r)
        {
            ObjectType = (int)r.ReadUInt16();
            Status.Read(r);

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write((ushort)ObjectType);
            Status.Write(w);
        }
    }
}