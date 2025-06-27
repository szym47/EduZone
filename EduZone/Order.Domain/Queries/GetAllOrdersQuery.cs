using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Domain.Queries
{
    public class GetAllOrdersQuery : IRequest<List<Order.Domain.Models.Order>> { }
}

