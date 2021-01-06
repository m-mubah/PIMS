using System;
using PIMS.API.Domain.Entities;
using PIMS.API.Domain.Enums;

namespace PIMS.API.Domain.Requests
{
    public class CreatePatientDto
    {
        public string RegistrationNumber { get; set; }
        public string HospitalNumber { get; set; }
        public string FullName { get; set; }
        public string Identification { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int PrimaryContactNumber { get; set; }
#nullable enable
        public int? SecondaryContactNumber { get; set; }
#nullable disable

        public int IslandId { get; set; }
#nullable enable
        public virtual CreatePatientHistoryDto? History { get; set; }
#nullable disable
    }
}
