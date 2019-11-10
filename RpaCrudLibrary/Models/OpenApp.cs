using RpaCrudLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Models
{
    public class OpenApp: IComponent
    {
        public int Id { get; private set; }

        public int IdSolution { get; set; }

        public string AppName { get; set; }

        public IList<string> Parameters { get; set; }
    }
}
