using System;

namespace ErisLib.Utilities
{
    public class ConsoleUtilities
    {
        public static void VerboseWriteLine(string value, string tag = null)
        {
            if (Constants.Verbose) {
                string t = tag == null ? "[VERBOSE]" : $"[{tag}]";
                ColorWriteLine($"{t} {value}", ConsoleColor.Gray);
            }
        }

        public static void ColorWriteLine(string value, ConsoleColor color)
        {
            // save last color
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = c;
        }
    }
}