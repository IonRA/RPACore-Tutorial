using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class WriteApp: Component
    {
        public Process ComponentProcess { get; set; }

        public int PID { get; set; }

        public string Message { get; set; }
    }
}
