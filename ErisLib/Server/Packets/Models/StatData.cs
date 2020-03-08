namespace ErisLib.Server.Packets.Models
{
    public class StatData
    {
        public StatsType Id;
        public int IntValue;
        public string StringValue;

        public bool IsStringData()
        {
            return Id.IsUTF();
        }

        public StatData Read(PacketReader r)
        {
            Id = r.ReadByte();
            if (IsStringData()) StringValue = r.ReadString();
            else IntValue = r.ReadInt32();

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(Id);
            if (IsStringData()) w.Write(StringValue);
            else w.Write(IntValue);
        }
    }
}