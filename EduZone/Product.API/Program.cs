using Product.Application;
using Product.Application.Services;
using Product.Domain.Repositories;
using Product.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Product.API;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");


        //builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"), ServiceLifetime.Transient);
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Transient);
        builder.Services.AddScoped<IRepository, Repository>();


        // Add services to the container.
        builder.Services.AddScoped<CourseService, CourseService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();



        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        builder.Services.AddScoped<ICourseSeeder, CourseSeeder>();
        builder.Services.AddMemoryCache();

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            await db.Database.MigrateAsync();
            var seeder = scope.ServiceProvider.GetRequiredService<ICourseSeeder>();
            await seeder.Seed();
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();





        app.Run();
    }
}