using System;
using System.Linq;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions
{
    /// <summary>
    /// Get a local register
    /// </summary>
    public class GetLocal : IInstruction
    {
        /// <summary>
        /// Register to 'get' from
        /// </summary>
        public int Register;

        public GetLocal(int register) => Register = register;
        public GetLocal(string line) => Parse(line);
        
        public IInstruction Parse(string line)
        {
            string a = line.Split(' ')[line.Count(x => x == ' ')];
            
            // If the text AFTER the last space is the "getlocal" OpCode, then it's a unified instruction and not a separate one
            Register = Convert.ToInt32(a.Contains("local") 
                ? a.Split(new[] {"getlocal"}, StringSplitOptions.None)[1]
                : a);

            return this;
        }

        public void Write() => throw new System.NotImplementedException();

        public override string ToString() => "getlocal" + Register;
    }
}