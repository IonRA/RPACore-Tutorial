using RpaCrudLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpaCrudLibrary.Interfaces
{
    public interface IOpenAppManager
    {
        public Task CreateAsync(OpenApp openApp);

        public Task<OpenApp> AlterAsync(OpenApp openApp);

        public Task<OpenApp> GetAsync(int id);

        public Task DeleteAsync(int id);
    }
}
