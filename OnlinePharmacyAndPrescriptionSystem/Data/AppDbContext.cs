using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Models;

namespace OnlinePharmacyAndPrescriptionSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
    }
}
