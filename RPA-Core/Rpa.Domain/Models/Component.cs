using System;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces;

namespace Services.Rpa.Domain.Models
{
    abstract public class Component : IComponent
    {
        //public Guid Id { get; set; }
        public Guid ComponentId { get; set; }

        public int Position { get; set; }

        public Guid SolutionID { get; set; }

        public Solution Solution { get; set; }


    }
}
