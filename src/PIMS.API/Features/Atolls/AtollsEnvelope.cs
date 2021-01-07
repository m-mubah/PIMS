using System;
using System.Collections.Generic;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Features.Atolls
{
    public class AtollsEnvelope
    {
        public List<Atoll> Atolls { get; set; }

        public int Count { get; set; }
    }
}
