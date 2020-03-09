using ErisLib.Game;

namespace ErisLib
{
    public class Constants
    {
        /// <remarks>The XML Documents containing the GameData for Realm of the Mad God</remarks>
        public static GameData GameData;

        /// <remarks>Indicates whether the program is in Verbose mode or not. If it is, it will print debug information into the console</remarks>
        public static bool Verbose;

        public static void ConstructConstants(bool verbose)
        {
            GameData = new GameData();
            Verbose = verbose;
        }
    }
}