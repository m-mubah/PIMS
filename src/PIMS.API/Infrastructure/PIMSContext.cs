using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PIMS.API.Domain.Entities;
using PIMS.API.Infrastructure.SchemaConfigurations;

namespace PIMS.API.Infrastructure
{
    public class PIMSContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public PIMSContext(DbContextOptions options) : base(options) { }

        public DbSet<Atoll> Atolls { get; set; }
        public DbSet<Island> Islands { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseFollowup> CaseFollowups { get; set; }
        public DbSet<CaseTest> CaseTests { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<TestType> TestTypes { get; set; }

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

        #region Transaction Handling
        public void BeginTransaction()
        {
           if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CommitTransaction()
        {
            try
            {
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if(_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if(_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        #endregion
    }
}