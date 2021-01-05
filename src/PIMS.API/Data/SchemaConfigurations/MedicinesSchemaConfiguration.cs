using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Data.SchemaConfigurations
{
    public class MedicinesSchemaConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");
            builder.HasKey(k => k.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(120);
            builder.Property(m => m.GenericName).HasMaxLength(120);
            builder.Property(m => m.DeletedOn).HasDefaultValue(null);
        }
    }
}