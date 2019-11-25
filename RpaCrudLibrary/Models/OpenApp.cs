using System.Collections.Generic;

namespace RpaCrudLibrary.Models
{
    public class OpenApp: Component
    {
        public int IdSolution { get; set; }

        public string AppName { get; set; }

        public IList<string> Parameters { get; set; }
    }
}

