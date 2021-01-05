namespace PIMS.API.Domain.Entities
{
    public class CaseTest : EntityBase
    {
        #nullable enable
        public string? Details { get; set; }
        #nullable disable

        public int TypeId { get; set; }
        public virtual TestType Type { get; set; }
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}