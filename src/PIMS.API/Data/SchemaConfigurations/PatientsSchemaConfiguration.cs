using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class PatientsSchemaConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.RegistrationNumber).HasMaxLength(12);
            builder.Property(p => p.HospitalNumber).HasMaxLength(12);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Identification).IsRequired().HasMaxLength(12);
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Sex).IsRequired();
            builder.Property(p => p.PrimaryContactNumber).IsRequired().HasMaxLength(7);
            builder.Property(p => p.SecondaryContactNumber);
            builder.Property(p => p.DeletedOn).HasDefaultValue(null);

            builder.HasIndex(i => i.RegistrationNumber).IsUnique();
            builder.HasIndex(i => i.HospitalNumber).IsUnique();
            builder.HasIndex(i => i.Identification).IsUnique();

            builder.HasOne(p => p.Island).WithMany(i => i.Patients).HasForeignKey(p => p.IslandId);
            builder.HasOne(p => p.History);
        }
    }
}