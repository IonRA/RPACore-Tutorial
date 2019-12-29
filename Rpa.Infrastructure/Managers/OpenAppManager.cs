using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rpa.Infrastructure.Managers;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.Infrastructure.Managers
{
    public class OpenAppManager : BaseManager<OpenApp, IOpenAppRepository>, IOpenAppManager
    {

        public OpenAppManager(IOpenAppRepository repo) : base(repo)
        {
        }

    }
}