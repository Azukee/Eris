namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions
{
    /// <summary>
    /// Push an object onto the scope stack
    /// </summary>
    public class PushScope : IInstruction
    {
        // There isn't really anything to parse here - I just wanted to have this indexed.
        public IInstruction Parse(string line) => this;

        public void Write() => throw new System.NotImplementedException();

        public override string ToString() => "pushscope";
    }
}