using Microsoft.EntityFrameworkCore;
using Pessoas2.Models;


namespace Pessoas2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nome).IsRequired();
                entity.Property(e => e.idade).HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
