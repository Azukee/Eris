using ErisLib.Server.Packets.Models;

namespace ErisLib.Server.Packets.Server
{
    public class BuyResultPacket : Packet
    {
		/*
		UnknownError = -1
		Success = 0
		InvalidCharacter = 1
		ItemNotFound = 2
		NotEnoughGold = 3
		InventoryFull = 4
		TooLowRank = 5
		NotEnoughFame = 6
		PetFeedSuccess = 7
		TooManyResetsToday = 10
		*/

		public int Result;
        public string Message;
        public override PacketType Type => PacketType.BUYRESULT;

        public override void Read(PacketReader r)
        {
            Result = r.ReadInt32();
            Message = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Result);
            w.Write(Message);
        }
    }
}
