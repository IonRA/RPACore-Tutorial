using Rpa.Infrastructure.Managers;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.Infrastructure.Managers
{
    public class CloseAppManager: BaseManager<CloseApp, ICloseAppRepository>, ICloseAppManager
    {

        public CloseAppManager(ICloseAppRepository repo) : base(repo)
        {
        }

    }
}
