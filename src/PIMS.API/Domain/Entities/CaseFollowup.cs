using System;

namespace PIMS.API.Domain.Entities
{
    public class CaseFollowup : EntityBase
    {
        public string Diagnosis { get; set; }
        #nullable enable
        public string? Remarks { get; set; }
        public DateTime? NextFollowupDate { get; set; }
        #nullable disable

        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}