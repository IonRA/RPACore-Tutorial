using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Rpa.Domain.Interfaces
{
    interface IComponent
    {
        int Id { get; set; }

        int? SolutionID { get; set; }

        
    }
}
