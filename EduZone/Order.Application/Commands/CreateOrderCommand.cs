using MediatR;
using System;
using System.Collections.Generic;

namespace Order.Application.Commands
{
    public record CreateOrderCommand(Guid UserId, List<CreateOrderItemDto> Items) : IRequest<Guid>;

    public record CreateOrderItemDto(Guid ProductId, int Quantity);
}
