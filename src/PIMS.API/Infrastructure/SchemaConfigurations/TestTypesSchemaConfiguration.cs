using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Infrastructure.SchemaConfigurations
{
    public class TestTypesSchemaConfiguration : IEntityTypeConfiguration<TestType>
    {
        public void Configure(EntityTypeBuilder<TestType> builder)
        {
            builder.ToTable("Test_Types");
            builder.HasKey(k => k.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(120);
            builder.Property(t => t.Description).HasMaxLength(240);
            builder.Property(t => t.DeletedOn).HasDefaultValue(null);
        }
    }
}