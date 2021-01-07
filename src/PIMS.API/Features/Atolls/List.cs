using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PIMS.API.Domain.Entities;
using PIMS.API.Infrastructure;

namespace PIMS.API.Features.Atolls
{
    public class List
    {
        public record Query(int? Limit, int? Offset) : IRequest<AtollsEnvelope>;

        public class QueryHandler : IRequestHandler<Query, AtollsEnvelope>
        {
            private readonly PIMSContext _context;

            public QueryHandler(PIMSContext context)
            {
                _context = context;
            }

            public async Task<AtollsEnvelope> Handle(Query message, CancellationToken cancellationToken)
            {
                IQueryable<Atoll> queryable = _context.Atolls.GetAllData();

                //TODO: Select all atolls which contain an island with queryd name

                var atolls = await queryable
                             .OrderBy(x => x.Id)
                             .Skip(message.Offset ?? 0)
                             .Take(message.Limit ?? 20)
                             .AsNoTracking()
                             .ToListAsync(cancellationToken);

                return new AtollsEnvelope()
                {
                    Atolls = atolls,
                    Count = queryable.Count()
                };
            }
        }
    }
}
