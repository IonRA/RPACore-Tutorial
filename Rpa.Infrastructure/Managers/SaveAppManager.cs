using Rpa.Infrastructure.Managers;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.Infrastructure.Managers
{
    class SaveAppManager : BaseManager<SaveApp, ISaveAppRepository>, ISaveAppManager
    {

        public SaveAppManager(ISaveAppRepository repo) : base(repo)
        {
        }

    }
}
