using System;
using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class Case : EntityBase
    {
        public string CaseId { get; set; }
        public string Diagnosis { get; set; }
        #nullable enable
        public string? Remarks { get; set; }
        #nullable disable
        public bool Active { get; set; }
        public DateTime RegisteredDate { get; set; }
        
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int TypeId { get; set; }
        public virtual CaseType Type { get; set; }
        public IEnumerable<CaseFollowup> Followups { get; set; }
        public IEnumerable<CaseTest> Tests { get; set; }
        public IEnumerable<MedicineRequisition> Medicines { get; set; }
    }
}