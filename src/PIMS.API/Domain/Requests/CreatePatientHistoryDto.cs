using System;
namespace PIMS.API.Domain.Requests
{
    public class CreatePatientHistoryDto
    {
#nullable enable
        public string? CancerTreatment { get; set; }
        public string? Medical { get; set; }
        public string? Surgical { get; set; }
        public string? Familial { get; set; }
        public string? Other { get; set; }
    }
}
