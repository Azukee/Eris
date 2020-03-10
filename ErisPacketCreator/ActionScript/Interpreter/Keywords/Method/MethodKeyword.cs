using System;
using System.Collections.Generic;
using ErisPacketCreator.ActionScript.Interpreter.Keywords.Models;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method
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
        /// </summary>
        public List<QName> Parameters;

        /// <summary>
        /// The return type of the method
        /// </summary>
        public QName ReturnType;

        /// <summary>
        /// The Body of the method, containing info of the code and the code itself
        /// </summary>
        public BodyKeyword Body;

        public MethodKeyword(ActionScriptReader acr)
        {
            Parameters = new List<QName>();
            Parse(acr);
        }
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            if (!acr.ReadString().Contains("method"))
                return null;

            Name = acr.ReadString().Split('"')[1];
            ReferenceId = acr.ReadString();

            while(acr.PeekString().Contains("param"))
                Parameters.Add(acr.ReadString().Split(new []{"param "}, StringSplitOptions.None)[1]);
            
            ReturnType = acr.ReadString().Split(new []{"returns "}, StringSplitOptions.None)[1];
            
            if (acr.PeekString().Contains("body"))
                Body = new BodyKeyword(acr); 
            
            return this;
        }
    }
}