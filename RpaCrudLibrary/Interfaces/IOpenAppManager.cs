using RpaCrudLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpaCrudLibrary.Interfaces
{
    public interface IOpenAppManager
    {
        public Task Create(OpenApp openApp);

        public Task<OpenApp> Alter(int id, OpenApp openApp);

        public Task<OpenApp> Get(int id);

        public Task Delete(int id);
    }
}
