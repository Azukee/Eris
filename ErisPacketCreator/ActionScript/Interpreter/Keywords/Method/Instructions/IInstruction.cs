using System;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions
{
    public interface IInstruction
    {
        IInstruction Parse(string line);
        
        void Write();

        string ToString();
    }
}