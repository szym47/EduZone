using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Domain.Queries
{
    public class GetOrderByIdQuery : IRequest<Order.Domain.Models.Order>
    {
        public int OrderId { get; set; }
    }
}

