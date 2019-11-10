using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpaCrudLibrary.Interfaces;
using RpaCrudLibrary.Models;

namespace RpaCrudLibrary.Managers
{
    public class OpenAppManager: IOpenAppManager
    {
        public async Task Create(OpenApp openApp)
        {

        }

        public async Task<OpenApp> Alter(int id, OpenApp openApp)
        {
            return new OpenApp();
        }

        public async Task<OpenApp> Get(int id)
        {
            return new OpenApp();
        }

        public async Task Delete(int id)
        {

        }
    }
}
