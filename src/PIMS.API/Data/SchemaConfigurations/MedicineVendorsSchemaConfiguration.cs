using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class MedicineVendorsSchemaConfiguration : IEntityTypeConfiguration<MedicineVendor>
    {
        public void Configure(EntityTypeBuilder<MedicineVendor> builder)
        {
            builder.ToTable("Medicine_Vendors");
            builder.HasKey(k => k.Id);

            builder.Property(v => v.Name).IsRequired().HasMaxLength(120);
            builder.Property(v => v.PrimaryContactNumber).IsRequired().HasMaxLength(7);
            builder.Property(v => v.SecondaryContactNumber).HasMaxLength(7);
            builder.Property(v => v.DeletedOn).HasDefaultValue(null);
        }
    }
}