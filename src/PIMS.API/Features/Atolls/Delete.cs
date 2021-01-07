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
    public class Delete
    {
        public record Command(int Id) : IRequest;

        public class QueryHandler : IRequestHandler<Command>
        {
            private readonly PIMSContext _context;

            public QueryHandler(PIMSContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command message, CancellationToken cancellationToken)
            {
                var atoll = await _context.Atolls.FirstOrDefaultAsync(x => x.Id == message.Id, cancellationToken);

                if(atoll == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Atoll = Constants.NOT_FOUND });
                }

                _context.Atolls.Remove(atoll);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
