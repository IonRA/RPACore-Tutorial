using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Repositories
{
    class WriteAppRepository : BaseRepository<WriteApp>, IWriteAppRepository
    {
        public WriteAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
