using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PIMS.API.Domain.Enums;

namespace PIMS.API.Domain.Entities
{
    public class Patient : EntityBase
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
        [JsonIgnore]
        public virtual Island Island { get; set; }
        public virtual PatientHistory History { get; set; }
        [JsonIgnore]
        public IEnumerable<Case> Cases { get; set; }
    }
}