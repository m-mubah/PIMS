using System.Collections.Generic;
using PIMS.API.Domain.Enums;

namespace PIMS.API.Domain.Entities
{
    public class CaseType : EntityBase
    {
        public string Name { get; set; }
        public IllnessCategory Type { get; set; }

        public IEnumerable<Case> Cases { get; set; }
    }
}