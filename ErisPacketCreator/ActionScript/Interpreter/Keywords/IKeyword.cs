namespace ErisPacketCreator.ActionScript.Interpreter.Keywords
{
    public interface IKeyword
    {
        IKeyword Parse(ActionScriptReader acr);
    }
}