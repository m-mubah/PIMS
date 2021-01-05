using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class Atoll : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public IEnumerable<Island> Islands { get; set; }
    }
}