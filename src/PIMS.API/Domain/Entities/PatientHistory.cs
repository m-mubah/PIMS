namespace PIMS.API.Domain.Entities
{
    public class PatientHistory : EntityBase
    {
#nullable enable
        public string? CancerTreatment { get; set; }
        public string? Medical { get; set; }
        public string? Surgical { get; set; }
        public string? Familial { get; set; }
        public string? Other { get; set; }
# nullable disable

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}