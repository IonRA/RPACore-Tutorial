using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpaCoreTutorialMVC.ViewModels
{
    public class ResultVM
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public enum Status
    {
        Succes = 1,
        Error = 2
    }
}
