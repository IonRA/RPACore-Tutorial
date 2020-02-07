using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;
using Services.Rpa.MetadataDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rpa.Infrastructure.Repositories
{
    class CloseAppRepository : BaseRepository<CloseApp>, ICloseAppRepository
    {
        public CloseAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
