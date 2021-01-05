using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class CaseTestsSchemaConfiguration : IEntityTypeConfiguration<CaseTest>
    {
        public void Configure(EntityTypeBuilder<CaseTest> builder)
        {
            builder.ToTable("Case_Tests");
            builder.HasKey(k => k.Id);

            builder.Property(ct => ct.Details).HasMaxLength(240);
            builder.Property(ct => ct.DeletedOn).HasDefaultValue(null);

            builder.HasOne(ct => ct.Type).WithMany(t => t.CaseTests).HasForeignKey(ct => ct.TypeId);
            builder.HasOne(ct => ct.Case).WithMany(t => t.Tests).HasForeignKey(ct => ct.CaseId);
        }
    }
}