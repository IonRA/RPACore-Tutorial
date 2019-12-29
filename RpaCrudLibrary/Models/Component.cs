﻿using System;
using System.Threading.Tasks;
using RpaCrudLibrary.Interfaces;

namespace RpaCrudLibrary.Models
{
    abstract public class Component: IComponent
    {
        public int Id { get; set; }

        public int IdSolution { get; set; }
    }
}
