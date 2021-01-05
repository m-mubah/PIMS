using System;
using PIMS.API.Domain.Enums;

namespace PIMS.API.Domain.Entities
{
    public class MedicineRequisition : EntityBase
    { 
        public string FDAB { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
#nullable enable
        public string? RecievedBy { get; set; }
        public DateTime? RecievedDate { get; set; }
        public string? DispatchedBy { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public int AmountRemaining { get; set; }
        public string? Remarks { get; set; }
#nullable disable
        public MedicineRequisitionPriority Priority { get; set; }
        
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int VendorId { get; set; }
        public virtual MedicineVendor Vendor { get; set; }
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}