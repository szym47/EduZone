using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Domain.Commands
{
    public class CancelOrderCommand : IRequest
    {
        public int OrderId { get; set; }
    }
}
