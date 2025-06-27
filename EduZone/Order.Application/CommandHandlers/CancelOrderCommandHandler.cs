using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Order.Domain.Interfaces;
using Order.Domain.Commands;

namespace Order.Application.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderCanceler _canceler;

        public CancelOrderCommandHandler(IOrderCanceler canceler)
        {
            _canceler = canceler;
        }

        public Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            _canceler.CancelOrder(request.OrderId);
            return Task.CompletedTask;
        }
    }
}
