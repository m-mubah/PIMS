using System;

namespace PIMS.API.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
#nullable enable
        public DateTime? DeletedOn { get; set; }
#nullable disable
    }
}