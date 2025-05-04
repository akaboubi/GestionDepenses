using GestionDepenses.Models;
using Microsoft.EntityFrameworkCore;


namespace GestionDepenses.Data
{
    public class DepenseContext : DbContext
    {
        public DepenseContext(DbContextOptions<DepenseContext> options) : base(options) { }

        public DbSet<Depense> Depenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depense>()
                .HasCheckConstraint("CK_Depense_Distance_NonNull", "[Nature] != 0 OR [Distance] IS NOT NULL");
        }
    }
}
