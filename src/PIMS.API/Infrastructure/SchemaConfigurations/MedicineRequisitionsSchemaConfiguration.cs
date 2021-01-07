using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.API.Domain.Entities;

namespace PIMS.API.Infrastructure.SchemaConfigurations
{
    public class MedicinesRequisitionsSchemaConfiguration : IEntityTypeConfiguration<MedicineRequisition>
    {
        public void Configure(EntityTypeBuilder<MedicineRequisition> builder)
        {
            builder.ToTable("Medicine_Requisitions");
            builder.HasKey(k => k.Id);

            builder.Property(r => r.FDAB).HasMaxLength(240);
            builder.Property(r => r.RequestedBy).IsRequired().HasMaxLength(120);
            builder.Property(r => r.RecievedBy).HasMaxLength(120);
            builder.Property(r => r.DispatchedBy).HasMaxLength(120);
            builder.Property(r => r.AmountRemaining).HasMaxLength(100);
            builder.Property(r => r.Remarks).HasMaxLength(240);
            builder.Property(r => r.DeletedOn).HasDefaultValue(null);

            builder.HasOne(r => r.Medicine).WithMany(m => m.Requisitions).HasForeignKey(r => r.MedicineId);
            builder.HasOne(r => r.Vendor).WithMany(v => v.Requisitions).HasForeignKey(r => r.VendorId);
            builder.HasOne(r => r.Case).WithMany(c => c.Medicines).HasForeignKey(r => r.CaseId);
        }
    }
}