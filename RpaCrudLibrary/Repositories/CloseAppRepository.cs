using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Repositories
{
    class CloseAppRepository : BaseRepository<CloseApp>, ICloseAppRepository
    {
        public CloseAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
