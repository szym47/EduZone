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

            if (!context.Courses.Any())
            {
                var category = await context.Categories
                    .FirstOrDefaultAsync(c => c.Name == "Programowanie");

                var course = new Course
                {
                    Title = "Podstawy C#",
                    Description = "Kurs wprowadzający do języka C#",
                    Price = 99.99m,
                    Category = category!,
                    VideoMaterials = new List<VideoMaterial>
                    {
                        new VideoMaterial { Title = "Wstęp do C#", Url = "https://example.com/video1" },
                        new VideoMaterial { Title = "Zmienne i typy danych", Url = "https://example.com/video2" }
                    },
                    PdfMaterials = new List<PdfMaterial>
                    {
                        new PdfMaterial { Title = "Notatki PDF", FilePath = "/files/csharp_intro.pdf" }
                    }
                };

                context.Courses.Add(course);
                await context.SaveChangesAsync();
            }
        }
    }
}
