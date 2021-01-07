using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PIMS.API.Infrastructure
{
    public class DBContextTransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly PIMSContext _context;

        public DBContextTransactionPipelineBehavior(PIMSContext context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse result = default(TResponse);

            try
            {
                _context.BeginTransaction();

                result = await next();

                _context.CommitTransaction();
            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                throw;
            }

            return result;
        }
    }
}
