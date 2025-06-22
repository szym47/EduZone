using MediatR;
using System;

namespace Order.Application.Commands
{
    // Komenda anulowania zamówienia przyjmująca identyfikator zamówienia
    public record CancelOrderCommand : IRequest<Unit>
    {
        public Guid OrderId { get; init; }
    }
}
