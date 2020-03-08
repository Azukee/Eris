using System;

namespace ErisLib.Server.Packets.Models
{
    public class Location
    {
        public float X;
        public float Y;

        public Location() { }

        public Location(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Location Empty
        {
            get
            {
                return new Location()
                {
                    X = 0,
                    Y = 0
                };
            }
        }

        public virtual Location Read(PacketReader r)
        {
            X = r.ReadSingle();
            Y = r.ReadSingle();

            return this;
        }

        public virtual void Write(PacketWriter w)
        {
            w.Write(X);
            w.Write(Y);
        }

        public float DistanceSquaredTo(Location location)
        {
            float dx = location.X - X;
            float dy = location.Y - Y;
            return dx * dx + dy * dy;
        }

        public float DistanceTo(Location location)
        {
            return (float)Math.Sqrt(DistanceSquaredTo(location));
        }

        private float GetAngle(Location l1, Location l2)
        {
            float dX = l2.X - l1.X;
            float dY = l2.Y - l1.Y;
            return (float)Math.Atan2(dY, dX);
        }

        private float GetAngle(float x1, float y1, float x2, float y2)
        {
            float dX = x2 - x1;
            float dY = y2 - y1;
            return (float)Math.Atan2(dY, dX);
        }
    }
}