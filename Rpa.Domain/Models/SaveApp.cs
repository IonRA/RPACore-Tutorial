using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rpa.Domain.Models
{
    public class SaveApp: Component
    {
        public IntPtr WindowHandler { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }
    }
}
