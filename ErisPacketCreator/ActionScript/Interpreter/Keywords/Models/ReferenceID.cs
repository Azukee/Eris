namespace ErisPacketCreator.ActionScript.Interpreter.Keywords.Models
{
    public class ReferenceId
    {
        private string _rawId;

        /// <summary>
        /// Creates a new ReferenceId Instance, and splits the string to make it easier to use
        /// </summary>
        /// <param name="rawString">The raw line from the rabcdasm output</param>
        private ReferenceId(string rawString)
        {
            _rawId = rawString;
            string full = _rawId.Split('"')[1];
            Namespace = full.Split(':')[0];
            Name = full.Split(':')[1];
        }

        /// <summary>
        /// Returns the Name of the class, e.g. the name after the Colon
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Returns the Namespace of the class, e.g. the name before the Colon
        /// </summary>
        public string Namespace { get; }

        public static implicit operator ReferenceId(string x) => new ReferenceId(x);
    }
}