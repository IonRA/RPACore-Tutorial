using RpaCrudLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Interfaces
{
    public interface IOpenAppManager
    {
        public void Create(OpenApp openApp);

        public OpenApp Alter(int id, OpenApp openApp);

        public OpenApp Get(int id);

        public void Delete(int id);
    }
}
