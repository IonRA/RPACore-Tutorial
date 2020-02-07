using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Rpa.Domain.Models
{
    public class OpenApp: Component
    {
        public string AppName { get; set; }

        public bool UseShell { get; set; }

    }
}

