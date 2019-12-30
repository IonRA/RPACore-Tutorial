using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class CloseApp: Component
    {
        public Process ComponentProcess { get; set; }

        public int PID { get; set; }
    }
}
