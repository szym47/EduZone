using Product.Domain.Repositories;
using ProductDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Xunit;

namespace ProductTests.Integration
{
    public class CourseApiIntegrationTests : IClassFixture<WebApplicationFactory<Product.API.Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Product.API.Program> _factory;

        public CourseApiIntegrationTests(WebApplicationFactory<Product.API.Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Usuń istniejący DbContext konfiguracji
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);

                    // Dodaj InMemory bazę danych na potrzeby testów
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });

                    // Po zarejestrowaniu DbContext, utwórz i zasiej dane
                    var sp = services.BuildServiceProvider();
                    using var scope = sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    var category = new Category { Name = "Test Category" };
                    db.Categories.Add(category);
                    db.SaveChanges();

                    db.Courses.Add(new Course
                    {
                        Name = "Test Course 1",
                        Ean = "EAN001",
                        Price = 100m,
                        Stock = 10,
                        Sku = "SKU001",
                        Category = category
                    });
                    db.Courses.Add(new Course
                    {
                        Name = "Test Course 2",
                        Ean = "EAN002",
                        Price = 200m,
                        Stock = 20,
                        Sku = "SKU002",
                        Category = category
                    });
                    db.SaveChanges();
                });
            });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCourses_ReturnsTwoCourses()
        {
            // Act
            var response = await _client.GetAsync("/api/course");

            // Assert
            response.EnsureSuccessStatusCode();

            var courses = await response.Content.ReadFromJsonAsync<List<Course>>();
            Assert.NotNull(courses);
            Assert.Equal(2, courses.Count);
            Assert.Contains(courses, c => c.Name == "Test Course 1");
            Assert.Contains(courses, c => c.Name == "Test Course 2");
        }

        [Fact]
        public async Task AddCourse_AddsCourseSuccessfully()
        {
            // Arrange
            var newCourse = new Course
            {
                Name = "New Test Course",
                Ean = "EAN003",
                Price = 150m,
                Stock = 15,
                Sku = "SKU003",
                Category = new Category { Name = "Test Category" }
            };
            var json = JsonConvert.SerializeObject(newCourse);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/course", content);

            // Assert
            response.EnsureSuccessStatusCode();

            // Sprawdź, czy kurs został dodany do bazy
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            var addedCourse = await db.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Name == "New Test Course");

            Assert.NotNull(addedCourse);
            Assert.Equal("EAN003", addedCourse.Ean);
            Assert.Equal(150m, addedCourse.Price);
            Assert.Equal("Test Category", addedCourse.Category.Name);
        }
    }
}
