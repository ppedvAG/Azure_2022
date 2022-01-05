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
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Personen_Dev;Trusted_Connection=true");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=tcp:mydbserver10000.database.windows.net,1433;Initial Catalog=hallodb;Persist Security Info=False;User ID=Fred;Password=nJhHG$@r=L&54hz#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
