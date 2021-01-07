using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Infrastructure.SchemaConfigurations
{
    public class CaseTypesConfiguration : IEntityTypeConfiguration<CaseType>
    {
        public void Configure(EntityTypeBuilder<CaseType> builder)
        {
            builder.ToTable("Case_Types");
            builder.HasKey(k => k.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(120);
            builder.Property(t => t.Type).IsRequired();
            builder.Property(t => t.DeletedOn).HasDefaultValue(null);
        }
    }
}