using MediatR;
using Order.Domain.Interfaces;
using Order.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Domain.Queries;
using Order.Infrastructure.Repositories;

namespace Order.Domain.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order.Domain.Models.Order>
    {
        private readonly IOrderRepository _repo;
        public GetOrderByIdQueryHandler(IOrderRepository repo) => _repo = repo;

        public Task<Order.Domain.Models.Order> Handle(GetOrderByIdQuery q, CancellationToken ct)
            => Task.FromResult(_repo.FindById(q.OrderId));
    }
}