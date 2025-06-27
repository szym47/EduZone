using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Order.Domain.Models;
using Order.Domain.Queries;
using Order.Infrastructure.Repositories;

namespace Order.Domain.QueryHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order.Domain.Models.Order>>
    {
        private readonly IOrderRepository _repo;
        public GetAllOrdersQueryHandler(IOrderRepository repo) => _repo = repo;

        public Task<List<Order.Domain.Models.Order>> Handle(GetAllOrdersQuery q, CancellationToken ct)
            => Task.FromResult(_repo.GetAll());
    }
}
