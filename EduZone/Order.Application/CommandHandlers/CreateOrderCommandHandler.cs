using MediatR;
using Order.Domain.Interfaces;
using Order.Domain.Models;
using Order.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;
using Order.Infrastructure.Repositories;

namespace Order.Domain.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _repo;
        public CreateOrderCommandHandler(IOrderRepository repo) => _repo = repo;

        public Task<int> Handle(CreateOrderCommand cmd, CancellationToken ct)
        {
            var order = new Order.Domain.Models.Order
            {
                UserId = cmd.UserId,
                Products = new List<OrderItem> { new OrderItem { ProductId = cmd.ProductId } }
            };
            _repo.Add(order);
            return Task.FromResult(order.Id);
        }
    }
}