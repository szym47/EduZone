using Product.Domain.Repositories;
using ProductDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Domain.Seeders
{
    public class ProductSeeder(DataContext context) : IProductSeeder
    {
        public async Task Seed()
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Programowanie" },
                    new Category { Name = "Matematyka" },
                    new Category { Name = "Języki obce" }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            if (!context.Courses.Any())
            {
                var category = await context.Categories
                        .Where(x => x.Name == "Programowanie").FirstOrDefaultAsync();

                var courses = new List<Course>
                {
                    new Course { Name = "VideoMaterial", Ean = "1234", Category = category },
                    new Course { Name = "PdfMaterial", Ean = "431", Category = category },
                    new Course { Name = "Online1hMeeting", Ean = "12212", Category = category }
                };


                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
        }
    }
}
