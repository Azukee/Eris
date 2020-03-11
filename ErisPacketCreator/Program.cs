using System;
using System.IO;
using System.Linq;
using ErisPacketCreator.ActionScript.Interpreter;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions;

namespace ErisPacketCreator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InterpretASAsm iasm = new InterpretASAsm(Directory.GetCurrentDirectory() + @"\something.asasm");
            iasm.Parse();
            
            var codeInstructions = iasm.ClassKeyword.Instance.Methods.FirstOrDefault(
                a => a.Name.Contains("write"))?.Body.Code.Instructions;

            if (codeInstructions != null)
                foreach (IInstruction instruction in codeInstructions) {
                    
                }

            Console.ReadKey();
        }
    }
}