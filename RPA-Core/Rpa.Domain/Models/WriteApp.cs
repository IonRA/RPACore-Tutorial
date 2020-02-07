using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace Services.Rpa.Domain.Models
{
    public class WriteApp: Component
    {
        [NotMapped]
        [JsonIgnore]
        public Process ComponentProcess { get; set; }

        public string Message { get; set; }
    }
}
