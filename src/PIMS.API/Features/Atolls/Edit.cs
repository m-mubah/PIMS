using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PIMS.API.Infrastructure;
using PIMS.API.Infrastructure.Errors;

namespace PIMS.API.Features.Atolls
{
    public class Edit
    {
        public class EditAtollData
        {
            public string Name { get; set; }

            public string code { get; set; }
        }

        public class EditAtollCommand: IRequest<AtollEnvelope>
        {
            public EditAtollData Atoll { get; set; }
            public int Id { get; set; }
        }

        public class CommandValidator: AbstractValidator <EditAtollCommand>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Atoll).NotNull();
            }
        }

        public class Handler : IRequestHandler<EditAtollCommand, AtollEnvelope>
        {
            private readonly PIMSContext _context;

            public Handler(PIMSContext context)
            {
                _context = context;
            }

            public async Task<AtollEnvelope> Handle(EditAtollCommand message, CancellationToken cancellationToken)
            {
                var atoll = await _context.Atolls.Where(x => x.Id == message.Id)
                            .FirstOrDefaultAsync(cancellationToken);

                if (atoll == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Atoll = Constants.NOT_FOUND });
                }

                atoll.Name = message.Atoll.Name ?? atoll.Name;
                atoll.Code = message.Atoll.code ?? atoll.Code;

                await _context.SaveChangesAsync(cancellationToken);

                return new AtollEnvelope(atoll);
            }
        }
    }
}
