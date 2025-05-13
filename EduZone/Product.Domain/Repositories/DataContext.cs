using ProductDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Domain.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}
