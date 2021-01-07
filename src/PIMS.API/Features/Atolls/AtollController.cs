using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIMS.API.Infrastructure;

namespace PIMS.API.Features.Atolls
{
    [ApiController]
    [Route("api/atolls")]
    public class AtollController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<AtollsEnvelope> Get([FromQuery] int? limit, [FromQuery] int? offset, CancellationToken cancellationToken)
        {
            return _mediator.Send(new List.Query(limit, offset), cancellationToken);
        }

        [HttpGet("{id:int}")]
        public Task<AtollEnvelope> Get(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new Details.Query(id), cancellationToken);
        }

        [HttpPost]
        public Task<AtollEnvelope> Create([FromBody] Create.CreateAtollCommand command, CancellationToken cancellationToken)
        {
            return _mediator.Send(command, cancellationToken);
        }

        [HttpPut("{id:int}")]
        public Task<AtollEnvelope> Edit(int id, [FromBody] Edit.EditAtollData data, CancellationToken cancellationToken)
        {
            Edit.EditAtollCommand command = new Edit.EditAtollCommand { Id = id, Atoll = data };
            return _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id:int}")]
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new Delete.Command(id), cancellationToken);
        }
    }
}
