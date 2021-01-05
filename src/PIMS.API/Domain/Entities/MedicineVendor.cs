using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class MedicineVendor : EntityBase
    {
        public string Name { get; set; }
        public int PrimaryContactNumber { get; set; }
        #nullable enable
        public int? SecondaryContactNumber { get; set; }
        #nullable disable
        public IEnumerable<MedicineRequisition> Requisitions { get; set; }
    }
}
