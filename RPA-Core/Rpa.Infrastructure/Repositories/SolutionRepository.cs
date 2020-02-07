using System;
using System.Collections.Generic;
using System.Text;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;
using Services.Rpa.MetadataDbContext;

namespace Services.Rpa.Infrastructure.Repositories
{
    class SolutionRepository: ISolutionRepository
    {
        public SolutionRepository(RpaContext rpaContext)
        { 
        }
    }
}
