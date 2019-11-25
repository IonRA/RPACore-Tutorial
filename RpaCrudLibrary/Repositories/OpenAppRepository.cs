using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpaCrudLibrary.Repositories
{
    public class OpenAppRepository: BaseRepository<OpenApp>, IOpenAppRepository
    {
        public OpenAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
