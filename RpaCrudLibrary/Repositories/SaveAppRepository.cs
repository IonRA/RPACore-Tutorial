using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Repositories
{
    class SaveAppRepository : BaseRepository<SaveApp>, ISaveAppRepository
    {
        public SaveAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
