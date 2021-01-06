using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}