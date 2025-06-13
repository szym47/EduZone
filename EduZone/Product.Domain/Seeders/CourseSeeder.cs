using Product.Domain.Repositories;
using ProductDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Domain.Seeders
{
    public class CourseSeeder(DataContext context) : ICourseSeeder
    {
        public async Task Seed()
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Programowanie" },
                    new Category { Name = "Matematyka" },
                    new Category { Name = "Języki obce" },
                    new Category { Name = "Biznes i marketing" },
                    new Category { Name = "Design i UX" }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            if (!context.Courses.Any())
            {
                var programmingCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Programowanie");
                var mathCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Matematyka");

                var courses = new List<Course>
                {
                    new Course { Name = "C# od podstaw", Ean = "C1234", Price = 199.99m, Stock = 50, Sku = "C-SHARP-001", Category = programmingCategory! },
                    new Course { Name = "ASP.NET Core MVC", Ean = "C5678", Price = 249.99m, Stock = 30, Sku = "ASP-NET-001", Category = programmingCategory! },
                    new Course { Name = "Matematyka dyskretna", Ean = "M1122", Price = 149.00m, Stock = 20, Sku = "MATH-001", Category = mathCategory! },
                    new Course { Name = "Algebra liniowa", Ean = "M3344", Price = 129.00m, Stock = 15, Sku = "MATH-002", Category = mathCategory! },
                    new Course { Name = "SQL i relacyjne bazy danych", Ean = "C9012", Price = 179.99m, Stock = 25, Sku = "SQL-001", Category = programmingCategory! }
                };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}
