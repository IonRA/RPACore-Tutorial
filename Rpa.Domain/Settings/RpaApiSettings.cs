using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Rpa.Domain.Settings
{
    public class RpaApiSettings
    {
        public MetadataDbContextSettings MetadataDbContextSettings { get; set; }
    }

    public class MetadataDbContextSettings
    {
        public string ConnectionString { get; set; }
    }
}
