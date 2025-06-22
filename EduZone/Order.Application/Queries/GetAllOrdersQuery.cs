using MediatR;
using Order.Application.DTOs;
using System.Collections.Generic;

namespace Order.Application.Queries
{
    // Zapytanie bez parametrów, zwracające listę DTO zamówień
    public record GetAllOrdersQuery() : IRequest<List<OrderDto>>;
}
