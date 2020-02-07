using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class WriteApp: Component
    {
        [NotMapped]
        public Process ComponentProcess { get; set; }

        public int PID { get; set; }

        public string Message { get; set; }

    }
}
