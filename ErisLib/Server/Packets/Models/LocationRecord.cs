namespace ErisLib.Server.Packets.Models
{
    public class LocationRecord : Location
    {
        public int Time;

        public override Location Read(PacketReader r)
        {
            Time = r.ReadInt32();
            base.Read(r);

            return this;
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            base.Write(w);
        }
    }
}