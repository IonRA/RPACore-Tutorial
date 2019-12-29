using Rpa.Infrastructure.Managers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rpa.Infrastructure.Managers
{
    class WriteAppManager : BaseManager<WriteApp, IWriteAppRepository>, IWriteAppManager
    {

        public WriteAppManager(IWriteAppRepository repo) : base(repo)
        {
        }

    }
}
