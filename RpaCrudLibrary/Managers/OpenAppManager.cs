using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpaCrudLibrary.Interfaces;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;

namespace RpaCrudLibrary.Managers
{
    public class OpenAppManager: IOpenAppManager
    {
        private readonly RpaContext _rpaContext;

        public OpenAppManager(RpaContext rpaContext)
        {
            _rpaContext = rpaContext;
        }
        public async Task CreateAsync(OpenApp openApp)
        {
            if (openApp != null)
            {
                await _rpaContext.OpenAppComponents.AddAsync(openApp);
                await _rpaContext.SaveChangesAsync();
            }
        }

        public async Task<OpenApp> AlterAsync(OpenApp openApp)
        {
            var existingComponent = _rpaContext.OpenAppComponents.
                                    Where(c => c.Id == openApp.Id).
                                    FirstOrDefault<OpenApp>();

            if (existingComponent != null)
            {
                existingComponent.AppName = openApp.AppName;
                existingComponent.Parameters = openApp.Parameters;
                existingComponent.IdSolution = openApp.IdSolution;

                await _rpaContext.SaveChangesAsync();

                return openApp;
            }

            return null;
        }

        public async Task<OpenApp> GetAsync(int id)
        {
            var component = await Task.Factory.StartNew(() =>
                            _rpaContext.OpenAppComponents.Where((c) => c.Id == id).FirstOrDefault()
                            );

            return component;
        }

        public async Task DeleteAsync(int id)
        {
            var component = _rpaContext.OpenAppComponents.Where((c) => c.Id == id).FirstOrDefault();

            _rpaContext.Remove<OpenApp>(component);

            await _rpaContext.SaveChangesAsync();
        }
    }
}
