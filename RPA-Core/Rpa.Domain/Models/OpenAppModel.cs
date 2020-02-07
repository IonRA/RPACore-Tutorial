using System;
using System.Collections.Generic;
using System.Text;

namespace Rpa.Domain.Models
{
    public class OpenAppModel
    {
        public int IdSolution { get; set; }
        public string AppName { get; set; }
        public bool UseShell { get; set; }
    }
}
