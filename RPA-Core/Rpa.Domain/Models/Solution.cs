using System;
using System.Collections.Generic;

namespace Services.Rpa.Domain.Models
{
    public class Solution
    {
        public Guid Id { get; set; }
        public ICollection<Component> Components { get; set; }

    }
}
