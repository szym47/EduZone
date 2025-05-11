using EduZoneDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace EduZone.Domain.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<VideoMaterial> VideoMaterials { get; set; }

        public DbSet<PdfMaterial> PdfMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2); // Precyzja: 18 cyfr, 2 miejsca po przecinku

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Precyzja: 18 cyfr, 2 miejsca po przecinku
        }

    }
}
