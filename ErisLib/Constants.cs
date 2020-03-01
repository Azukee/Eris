using ErisLib.Game;

namespace ErisLib
{
    public class Constants
    {
        /// <remarks>The XML Documents containing the GameData for Realm of the Mad God</remarks>
        public static GameData GameData;

        public static void ConstructConstants()
        {
            GameData = new GameData();;
        }
    }
}