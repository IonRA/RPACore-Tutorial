using System;
using System.Collections.Generic;
using System.Text;
using RpaCrudLibrary.Interfaces;
using RpaCrudLibrary.Models;

namespace RpaCrudLibrary.Managers
{
    public class OpenAppManager: IOpenAppManager
    {
        public void Create(OpenApp openApp)
        {

        }

        public OpenApp Alter(int id, OpenApp openApp)
        {
            return new OpenApp();
        }

        public OpenApp Get(int id)
        {
            return new OpenApp();
        }

        public void Delete(int id)
        {

        }
    }
}
