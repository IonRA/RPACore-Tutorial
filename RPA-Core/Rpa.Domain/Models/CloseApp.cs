using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class CloseApp: Component
    {
        [NotMapped]
        public Process ComponentProcess { get; set; }

    }
}
