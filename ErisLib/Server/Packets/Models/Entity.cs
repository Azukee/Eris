namespace ErisLib.Server.Packets.Models
{
    public class Entity
    {
        public short ObjectType;
        public Status Status = new Status();

        public Entity Read(PacketReader r)
        {
            ObjectType = r.ReadInt16();
            Status.Read(r);

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(ObjectType);
            Status.Write(w);
        }
    }
}