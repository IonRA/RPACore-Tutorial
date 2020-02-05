using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class SaveApp: Component
    {
        [NotMapped]
        public IntPtr WindowHandler { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }
    }
}
