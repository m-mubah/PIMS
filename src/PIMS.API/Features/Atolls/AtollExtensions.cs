using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Features.Atolls
{
    public static class AtollExtensions
    {
        public static IQueryable<Atoll> GetAllData(this DbSet<Atoll> atolls)
        {
            return atolls
                .Include(x => x.Islands)
                .AsNoTracking();
        }
    }
}
