namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method.Instructions
{
    public static class InstructionReader
    {
        public static IInstruction ParseInstruction(string line)
        {
            var trimmedString = line.TrimStart().Split(' ')[0].Replace("\n", "");

            switch (trimmedString) {
                case "getlocal":
                case "getlocal0":
                case "getlocal1":
                case "getlocal2":
                case "getlocal3":
                    return new GetLocal(line);
                case "pushscope":
                    return new PushScope();
                default:
                    return new Unknown(line);
            }
        }
    }
}