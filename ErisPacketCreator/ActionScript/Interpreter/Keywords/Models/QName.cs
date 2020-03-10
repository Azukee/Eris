using System;

namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Models
{
    public class QName
    {
        private string _rawQName;

        /// <summary>
        /// Creates a new QName Instance, and splits the string to make it easier to use
        /// </summary>
        /// <param name="rawString">The raw line from the rabcdasm output</param>
        private QName(string rawString)
        {
            _rawQName = rawString;
            PackageNamespace = _rawQName.Split('(')[2].Split(')')[0];
            Name = _rawQName.Split(')')[1].Split('"')[1];
        }

        /// <summary>
        /// Creates a new QName Instance from the entire Trait string, and splits the string to make it easier to use
        /// </summary>
        /// <param name="rawString">The raw line from the rabcdasm output</param>
        /// <param name="entireTrait">Is the string the entire trait string?</param>
        public QName(string rawString, bool entireTrait = true)
        { 
            //trait method QName(PackageNamespace(""), "writeToOutput") flag OVERRIDE
            _rawQName = rawString;
            if (entireTrait) {
                string split = _rawQName.Split(new[] {"QName"}, StringSplitOptions.None)[1];
                PackageNamespace = split.Split('(')[1].Split(')')[0];
                Name = split.Split(new[] {", \""}, StringSplitOptions.None)[1].Split('"')[0];
            }
        }

        /// <summary>
        /// Returns the PackageNamespace, first string from the QName call
        /// </summary>
        public string PackageNamespace { get; }
        
        /// <summary>
        /// Returns the Name of the Trait, second string fron the QName call
        /// </summary>
        public string Name { get; }

        public static implicit operator QName(string x) => new QName(x);
    }
}