using ErisPacketCreator.ActionScript.Interpreter.Keywords.Models;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords
{
    /// <summary>
    /// Models the Class Keyword from ActionScript Assembly
    /// </summary>
    public class ClassKeyword : IKeyword
    {
        /// <summary>
        /// The Reference ID ("refid" in ActionScript Assembly)
        /// </summary>
        public ReferenceId ReferenceId;

        /// <summary>
        /// The Instance of the class
        /// </summary>
        public InstanceKeyword Instance;

        /// <summary>
        /// The Class Initializer ("cinit" in ActionScript Assembly)
        /// <remarks>Currently pretty useless so it's not gonna hold anything</remarks>
        /// </summary>
        public ClassInitKeyword ClassInit;

        public ClassKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            ReferenceId = acr.ReadString();
            if (acr.PeekString().Contains("instance"))
                Instance = new InstanceKeyword(acr);
            ClassInit = new ClassInitKeyword(acr);
            
            return this;
        }
    }
}