using System;
using System.Linq;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Method
{
    /// <summary>
    /// Models the Body Keyword from ActionScript Assembly
    /// </summary>
    public class BodyKeyword : IKeyword
    {
        /// <summary>
        /// The MaxStack field is the maximum number of evaluation stack slots used at any point during the execution of this body.
        /// </summary>
        public int MaxStack;

        /// <summary>
        /// The LocalCount field is the index of the highest-numbered local register this method will use, plus one.
        /// </summary>
        public int LocalCount;

        /// <summary>
        /// The InitScopeDepth field defines the minimum scope depth, relative to MaxScopeDepth, that may be accessed within the method.
        /// </summary>
        public int InitScopeDepth;

        /// <summary>
        /// The MaxScopeDepth field defines the maximum scope depth that may be accessed within the method.
        /// The difference between MaxScopeDepth and InitScopeDepth determines the size of the local scope stack.
        /// </summary>
        public int MaxScopeDepth;

        /// <summary>
        /// Contains all the Code from the Body
        /// </summary>
        public CodeKeyword Code;

        public BodyKeyword(ActionScriptReader acr) => Parse(acr);
        
        public IKeyword Parse(ActionScriptReader acr)
        {
            acr.ReadString(); // skip "body" string
            string ms = acr.ReadString();
            MaxStack = Convert.ToInt32(ms.Split(' ')[ms.Count(a => a == ' ')]);
            string lc = acr.ReadString();
            LocalCount = Convert.ToInt32(lc.Split(' ')[lc.Count(a => a == ' ')]);
            string isd = acr.ReadString();
            InitScopeDepth = Convert.ToInt32(isd.Split(' ')[isd.Count(a => a == ' ')]);
            string msd = acr.ReadString();
            MaxScopeDepth = Convert.ToInt32(msd.Split(' ')[msd.Count(a => a == ' ')]);
            
            if (acr.PeekString().Contains("code"))
                Code = new CodeKeyword(acr);
            
            return this;
        }
    }
}