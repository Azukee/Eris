namespace ErisPacketCreator.ActionScript.Interpreter.Keywords
{
    /// <summary>
    /// The ClassInit ("cinit") Keyword that holds the static constructor for the class
    /// <remarks>Currently useless, so the class is empty</remarks>
    /// </summary>
    public class ClassInitKeyword : IKeyword
    {
        public ClassInitKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            return this;
        }
    }
}