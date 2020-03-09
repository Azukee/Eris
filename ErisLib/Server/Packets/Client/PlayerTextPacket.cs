using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Client
{
    /// <summary>
    /// The Packet that it sent from the client when the Player sends a text message in chat
    /// </summary>
    public class PlayerTextPacket : Packet
    {
        public string Text;

        public override PacketType Type => PacketType.PLAYERTEXT;

        public override void Read(PacketReader r) => Text = r.ReadString();

        public override void Write(PacketWriter w) => w.Write(Text);
    }
}