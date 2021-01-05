using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class Medicine : EntityBase
    {
        public string Name { get; set; }
        public string GenericName { get; set; }

        public IEnumerable<MedicineRequisition> Requisitions { get; set; }
    }
}