using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Infrastructure.SchemaConfigurations
{
    public class CasesSchemaConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.ToTable("Cases");
            builder.HasKey(k => k.Id);

            builder.Property(c => c.CaseId).IsRequired().HasMaxLength(7);
            builder.Property(c => c.Diagnosis).IsRequired();
            builder.Property(c => c.Remarks);
            builder.Property(c => c.Active).IsRequired();
            builder.Property(c => c.RegisteredDate).IsRequired();
            builder.Property(c => c.DeletedOn).HasDefaultValue(null);

            builder.HasIndex(i => i.CaseId);

            builder.HasOne(c => c.Patient).WithMany(p => p.Cases).HasForeignKey(c => c.PatientId);
            builder.HasOne(c => c.Type).WithMany(t => t.Cases).HasForeignKey(c => c.TypeId);
        }
    }
}