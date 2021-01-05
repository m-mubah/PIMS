using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class PatientHistoriesSchemaConfiguration : IEntityTypeConfiguration<PatientHistory>
    {
        public void Configure(EntityTypeBuilder<PatientHistory> builder)
        {
            builder.ToTable("Patient_Histories");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.CancerTreatment);
            builder.Property(p => p.Medical);
            builder.Property(p => p.Surgical);
            builder.Property(p => p.Familial);
            builder.Property(p => p.Other);
            builder.Property(p => p.DeletedOn).HasDefaultValue(null);

            builder.HasOne(h => h.Patient).WithOne(p => p.History).HasForeignKey<PatientHistory>(h => h.PatientId);
        }
    }
}