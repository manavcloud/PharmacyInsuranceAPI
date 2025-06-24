
using Microsoft.EntityFrameworkCore;
using PharmacyInsuranceAPI.Models;

namespace PharmacyInsuranceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<InsuranceCompany> InsuranceCompanies => Set<InsuranceCompany>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<DispenseRecord> DispenseRecords => Set<DispenseRecord>();
    }
}
