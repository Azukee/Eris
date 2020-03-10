using System.Collections.Generic;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Models;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords
{
    /// <summary>
    /// Models the Method Keyword from ActionScript Assembly
    /// </summary>
    public class MethodKeyword : IKeyword
    {
        /// <summary>
        /// The name of the method
        /// </summary>
        public string Name;
        
        /// <summary>
        /// The ReferenceId of the method (call path)
        /// </summary>
        public ReferenceId ReferenceId;

        /// <summary>
        /// List of all the parameters the method take
        /// <remarks>CURRENTLY NOT USED
        /// TODO: IMPLEMENT THIS
        /// </remarks>
        /// </summary>
        public List<QName> Parameters;

        /// <summary>
        /// The return type of the method
        /// <remarks>CURRENTLY NOT USED
        /// TODO: IMPLEMENT THIS
        /// </remarks>
        /// </summary>
        public QName ReturnType;
        
        public MethodKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            if (!acr.ReadString().Contains("method"))
                return null;

            Name = acr.ReadString().Split('"')[1];
            ReferenceId = acr.ReadString();

            acr.ReadStrings(2);
            
            return this;
        }
    }
}