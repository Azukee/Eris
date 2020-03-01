using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ErisLib.Game.Utils
{
    //Taken from KRelay
    public static class XDocumentExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> input, Action<T> action) {
            foreach (T element in input) {
                action(element);
            }
            return input;
        }
        
        public static bool HasElement(this XElement element, XName name) {
            return element.Elements(name).Any();
        }

        public static string AttrDefault(this XElement element, XName name, string @default) {
            return element.Attributes(name).Any() ? element.Attribute(name).Value : @default;
        }

        public static string ElemDefault(this XElement element, XName name, string @default) {
            return element.Elements(name).Any() ? element.Element(name).Value : @default;
        }

        public static int ParseHex(this string input) {
            return Convert.ToInt32(input, 16);
        }

        public static int ParseInt(this string input) {
            return int.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static float ParseFloat(this string input) {
            return float.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}