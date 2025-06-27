using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Domain.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}

