using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Infrastructure.SchemaConfigurations
{
    public class CaseFollowupsSchemaConfiguration : IEntityTypeConfiguration<CaseFollowup>
    {
        public void Configure(EntityTypeBuilder<CaseFollowup> builder)
        {
            builder.ToTable("Case_Followups");
            builder.HasKey(k => k.Id);

            builder.Property(f => f.Diagnosis).IsRequired().HasMaxLength(240);
            builder.Property(f => f.Remarks).HasMaxLength(240);
            builder.Property(f => f.NextFollowupDate);
            builder.Property(f => f.DeletedOn).HasDefaultValue(null);

            builder.HasOne(f => f.Case).WithMany(c => c.Followups).HasForeignKey(f => f.CaseId);
        }
    }
}