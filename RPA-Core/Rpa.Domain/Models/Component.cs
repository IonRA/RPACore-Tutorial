using System;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces;

namespace Services.Rpa.Domain.Models
{
    abstract public class Component : IComponent
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public int? SolutionID { get; set; }

        public virtual Solution Solution {get; set;}


    }
}
