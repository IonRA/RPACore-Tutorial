﻿using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;
using Services.Rpa.MetadataDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rpa.Infrastructure.Repositories
{
    public class OpenAppRepository: BaseRepository<OpenApp>, IOpenAppRepository
    {
        public OpenAppRepository(RpaContext rpaContext): base(rpaContext)
        {
        }
    }
}
