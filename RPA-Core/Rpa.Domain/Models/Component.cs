using System;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces;

namespace Services.Rpa.Domain.Models
{
    abstract public class Component : IComponent
    {
        public int Id { get; set; }

        public int position { get; set; }

        public int SolutionID { get; set; }

        public Solution Solution {get; set;}


    }
}
