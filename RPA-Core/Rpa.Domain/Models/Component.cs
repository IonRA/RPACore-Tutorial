using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces;

namespace Services.Rpa.Domain.Models
{
    abstract public class Component: IComponent
    {
        [Key]
        public Guid ComponentId { get; set; }

        public int IdSolution { get; set; }

    }
}
