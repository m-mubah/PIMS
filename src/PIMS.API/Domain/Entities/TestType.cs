using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class TestType : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<CaseTest> CaseTests { get; set; }
    }
}