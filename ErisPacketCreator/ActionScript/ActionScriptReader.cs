using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ErisPacketCreator.ActionScript
{
    public class ActionScriptReader : BinaryReader
    {
        public ActionScriptReader(Stream input) : base(input) { }

        /// <summary>
        /// Read until you find a new line
        /// </summary>
        /// <returns></returns>
        public override string ReadString()
        {
            bool foundNl = false;
            int foundAt = 0;
            
            // Always hold 10 characters of buffer
            byte[] buffer = new byte[10];
            
            while (!foundNl) {
                byte[] cache = base.ReadBytes(10);
                Array.ConstrainedCopy(cache, 0, buffer, 
                    buffer.All(a => a == 0x00) ? 0 : buffer.Length - cache.Length, cache.Length);

                for (int i = 0; i < buffer.Length; i++) 
                    if (buffer[i] == 0x0A) {
                        foundNl = true;
                        foundAt = i;
                    }

                if (!foundNl) 
                    Array.Resize(ref buffer, buffer.Length + 10);
            }
            
            // Now for the case that the buffer array was too big and the 0x0a appeared beforehand, we can skim the array
            byte[] stringBuffer = new byte[foundAt];
            Array.Copy(buffer, stringBuffer, foundAt);
            
            // Now reset the stream position for the bytes that we read too much
            base.BaseStream.Seek(-(buffer.Length - foundAt - 1), SeekOrigin.Current);

            return Encoding.ASCII.GetString(stringBuffer);
        }

        /// <summary>
        /// Read an entire string and reset the entire pointer, to peek the string
        /// </summary>
        /// <returns></returns>
        public string PeekString()
        {
            string str = ReadString();

            base.BaseStream.Seek(base.BaseStream.Position - str.Length - 1, SeekOrigin.Begin);

            return str;
        }

        /// <summary>
        /// Reads a specific number of strings and returns in them in an array
        /// </summary>
        /// <returns></returns>
        public string[] ReadStrings(int count)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < count; i++)
                strings.Add(ReadString());

            return strings.ToArray();
        }
    }
}