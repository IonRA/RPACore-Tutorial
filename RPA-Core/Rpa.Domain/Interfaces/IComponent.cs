using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Rpa.Domain.Interfaces
{
    interface IComponent
    {
        Guid ComponentId { get; set; }

        int IdSolution { get; set; }

    }
}
