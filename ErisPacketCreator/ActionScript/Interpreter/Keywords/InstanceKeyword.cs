using System.Collections.Generic;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Method;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Models;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords
{
    /// <summary>
    /// Models the Instance Keyword from ActionScript Assembly
    /// </summary>
    public class InstanceKeyword : IKeyword
    {
        /// <summary>
        /// The name of the instanced class
        /// </summary>
        public string InstanceName;

        /// <summary>
        /// If the Class doesn't inherit/extend anything, this string will be 'n/a'
        /// </summary>
        public string Extends = "n/a";
        
        public List<MethodKeyword> Methods = new List<MethodKeyword>();
        
        public InstanceKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            InstanceName = acr.ReadString().Split(',')[1].Split('"')[1];
            if (acr.PeekString().Contains("extends"))
                Extends = acr.ReadString().Split(',')[1].Split('"')[1];
            
            // Skip everything until method traits
            // TODO: Implement loading all other information later
DoCycle:
            while (!acr.PeekString().Contains("trait method") && !acr.PeekString().Contains("end ; instance")) {
                string xa;
                xa = acr.ReadString();
            }

            if (acr.PeekString().Contains("end ; instance"))
                return this;
            
            QName method = new QName(acr.ReadString());
            
            MethodKeyword mk = new MethodKeyword(acr);
            Methods.Add(mk);
            
goto DoCycle;
        }
    }
}