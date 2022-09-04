using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuraion) : base(dbContextOptions)
        {
            Configuration = configuraion;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(e =>
            {
                e.ToTable("Languages").HasKey(k => k.Id);
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.Name).HasColumnName("Name");
            });

            Language[] languageEntitySeeds = { new(1, "C#"), new(2, "Pyhton") };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);
        }
    }
}
