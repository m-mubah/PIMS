using Microsoft.EntityFrameworkCore;
using PIMS.API.Domain.Entities;
using PIMS.API.Data.SchemaConfigurations;

namespace PIMS.API.Data
{
    public class PIMSContext : DbContext
    {
        public DbSet<Atoll> Atolls { get; set; }
        public DbSet<Island> Islands { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseFollowup> CaseFollowups { get; set; }
        public DbSet<CaseTest> CaseTests { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<TestType> TestTypes { get; set; }

        public PIMSContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtollsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new IslandsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new PatientsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new PatientHistoriesSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new CasesSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new CaseFollowupsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new CaseTestsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new CaseTypesConfiguration());
            modelBuilder.ApplyConfiguration(new TestTypesSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new MedicinesSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineVendorsSchemaConfiguration());
            modelBuilder.ApplyConfiguration(new MedicinesRequisitionsSchemaConfiguration());
        }
    }
}