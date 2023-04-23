using DonutQueen.Models;
using Microsoft.EntityFrameworkCore;

namespace DonutQueen.Data
{
    public class DonutQueenContext : DbContext
    {
        public DonutQueenContext(DbContextOptions<DonutQueenContext> option) : base(option)
        {
        }

        public DbSet<Donut> Donuts { get; set; }
        public DbSet<Winkel> Winkels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donut>().ToTable("Donut").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Winkel>().ToTable("Winkel");
        }
    }
}