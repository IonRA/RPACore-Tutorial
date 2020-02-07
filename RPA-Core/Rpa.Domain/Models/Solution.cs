using System;
using System.Collections.Generic;

namespace Services.Rpa.Domain.Models
{
    public class Solution: Component
    {
        public ICollection<Component> Components { get; set; }

    }
}
