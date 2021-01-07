using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PIMS.API.Infrastructure;
using PIMS.API.Infrastructure.Errors;

namespace PIMS.API.Features.Atolls
{
    public class Details
    {
        public record Query(int id) : IRequest<AtollEnvelope>;

        public class QueryHandler : IRequestHandler<Query, AtollEnvelope>
        {
            private readonly PIMSContext _context;

            public QueryHandler(PIMSContext context)
            {
                _context = context;
            }

            public async Task<AtollEnvelope> Handle(Query message, CancellationToken cancellationToken)
            {
                var atoll = await _context.Atolls.GetAllData()
                    .FirstOrDefaultAsync(x => x.Id == message.id, cancellationToken);

                if (atoll == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Atoll = Constants.NOT_FOUND });
                }

                return new AtollEnvelope(atoll);
            }
        }
    }
}
