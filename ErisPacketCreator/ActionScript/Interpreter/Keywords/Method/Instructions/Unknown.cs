namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions
{
    public class Unknown : IInstruction
    {
        /// <summary>
        /// All data of the unknown instruction
        /// </summary>
        public string Data;

        public Unknown(string line) => Parse(line);
        
        public IInstruction Parse(string line)
        {
            Data = line;
            return this;
        }

        public void Write() => throw new System.NotImplementedException();

        public override string ToString() => Data;
    }
}