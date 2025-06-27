using MediatR;
using Order.Domain.Services;
using Order.Domain.Interfaces;
using Order.Infrastructure.Repositories;

namespace Order.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrderService).Assembly));

            builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
            builder.Services.AddSingleton<IOrderCreator, OrderService>();
            builder.Services.AddSingleton<IOrderCanceler, OrderService>();
            builder.Services.AddSingleton<IOrderReader, OrderService>();

            var app = builder.Build();

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
}
