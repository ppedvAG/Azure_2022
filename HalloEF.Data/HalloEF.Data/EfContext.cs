using HalloEF.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEF.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilungen> Abteilungen { get; set; }


        public EfContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Personen_Dev;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Personen");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");

            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(89).IsRequired();
        }

    }
}
