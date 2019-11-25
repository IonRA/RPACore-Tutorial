using RpaCrudLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RpaCrudLibrary.Interfaces.IManagers
{
    public interface IOpenAppManager
    {
        public Task<OpenApp> CreateAsync(OpenApp openApp);

        public Task<OpenApp> AlterAsync(OpenApp openApp);

        public Task<OpenApp> GetAsync(Expression<Func<OpenApp, bool>> expression);

        public Task<List<OpenApp>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
