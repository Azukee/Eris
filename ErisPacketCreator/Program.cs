using System;
using System.IO;
using ErisPacketCreator.ActionScript.Interpreter;

namespace ErisPacketCreator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InterpretASAsm iasm = new InterpretASAsm(Directory.GetCurrentDirectory() + @"\something.asasm");
            iasm.Parse();
            Console.ReadKey();
        }
    }
}