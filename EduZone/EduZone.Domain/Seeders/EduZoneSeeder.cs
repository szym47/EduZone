using EduZone.Domain.Repositories;
using EduZoneDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace EduZone.Domain.Seeders
{
    public class EduZoneSeeder(DataContext context) : IEduZoneSeeder
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

            if (!context.Products.Any())
            {
                var category = await context.Categories
                        .Where(x => x.Name == "Programowanie").FirstOrDefaultAsync();

                var products = new List<Product>
                {
                    new Product { Name = "VideoMaterial", Ean = "1234", Category = category },
                    new Product { Name = "PdfMaterial", Ean = "431", Category = category },
                    new Product { Name = "Online1hMeeting", Ean = "12212", Category = category }
                };


                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
