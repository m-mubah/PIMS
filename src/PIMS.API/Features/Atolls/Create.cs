using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PIMS.API.Domain.Entities;
using PIMS.API.Infrastructure;

namespace PIMS.API.Features.Atolls
{
    public class Create
    {
        public class CreateAtollData
        {
            public string Name { get; set; }

            public string Code { get; set; }
        }

        public class CreateAtollDataValidator : AbstractValidator<CreateAtollData>
        {
            public CreateAtollDataValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
                RuleFor(x => x.Code).NotEmpty().MaximumLength(5);
            }
        }

        public class CreateAtollCommand : IRequest<AtollEnvelope>
        {
            public CreateAtollData Atoll { get; set; }
        }

        public class CommandValidator : AbstractValidator<CreateAtollCommand>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Atoll).NotNull().SetValidator(new CreateAtollDataValidator());
            }
        }

        public class Handler : IRequestHandler<CreateAtollCommand, AtollEnvelope>
        {
            private readonly PIMSContext _context;

            public Handler(PIMSContext context)
            {
                _context = context;
            }

            public async Task<AtollEnvelope> Handle(CreateAtollCommand message, CancellationToken cancellationToken)
            {
                var atoll = new Atoll()
                {
                    Name = message.Atoll.Name,
                    Code = message.Atoll.Code
                };

                await _context.Atolls.AddAsync(atoll, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return new AtollEnvelope(atoll);
            }
        }
    }
}
