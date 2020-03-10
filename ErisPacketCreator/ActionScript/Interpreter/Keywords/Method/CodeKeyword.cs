using System.Collections.Generic;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method
{
    /// <summary>
    /// Models the Code Keyword from ActionScript Assembly
    /// </summary>
    public class CodeKeyword : IKeyword
    {
        /// <summary>
        /// A list of the Instructions contained in the Code keyword
        /// <remarks>I use a list here because I prefer lists. Deal with it uwu</remarks>
        /// </summary>
        public List<IInstruction> Instructions = new List<IInstruction>();
        
        public CodeKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            acr.ReadString(); // skip "code" string

            // While there's still instructions to be read, continue reading
            while (!acr.PeekString().Contains("returnvoid") && !acr.PeekString().Contains("returnvalue")) {
                string instr = acr.ReadString();
                if (!string.IsNullOrEmpty(instr)) {
                    Instructions.Add(InstructionReader.ParseInstruction(instr));
                }
            }
            
            return this;
        }
    }
}