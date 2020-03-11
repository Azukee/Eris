using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ErisPacketCreator.ActionScript.Interpreter.Keywords;

namespace ErisPacketCreator.ActionScript.Interpreter
{
    /// <summary>
    /// Interprets ActionScript Assembly created by rabcdasm output
    /// </summary>
    public class InterpretASAsm : IDisposable
    {
        public string File;

        public ClassKeyword ClassKeyword;
        
        private List<IKeyword> _allKeywords = new List<IKeyword>();
        
        public InterpretASAsm(string file)
        {
            File = file;
        }

        /// <summary>
        /// Parses all fields, keywords, etc. from the disassembled output
        /// </summary>
        public void Parse()
        {
            using (ActionScriptReader acr = new ActionScriptReader(new FileStream(File, FileMode.Open))) {
                string kw = acr.ReadString();
                if (kw == "class " || kw == "class") {
                    ClassKeyword = new ClassKeyword(acr);
                }
            }
        }

        public void Dispose()
        {
            File = null;
        }
    }
}