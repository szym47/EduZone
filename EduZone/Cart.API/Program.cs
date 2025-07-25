using MediatR;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CartService).Assembly));

        builder.Services.AddSingleton<ICartRepository, InMemoryCartRepository>();
        builder.Services.AddSingleton<ICartAdder, CartService>();
        builder.Services.AddSingleton<ICartRemover, CartService>();
        builder.Services.AddSingleton<ICartReader, CartService>();

        var app = builder.Build();

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