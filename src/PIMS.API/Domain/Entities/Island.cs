using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PIMS.API.Domain.Entities
{
    public class Island
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int AtollId { get; set; }
        [JsonIgnore]
        public virtual Atoll Atoll { get; set; }
        [JsonIgnore]
        public IEnumerable<Patient> Patients { get; set; }
    }
}