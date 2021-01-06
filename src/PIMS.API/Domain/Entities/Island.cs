using System.Collections.Generic;

namespace PIMS.API.Domain.Entities
{
    public class Island
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AtollId { get; set; }
        public virtual Atoll Atoll { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}