using MediatR;
using Order.Application.DTOs;
using System;

namespace Order.Application.Queries
{
    // Zapytanie przyjmujące identyfikator zamówienia i zwracające dane w postaci DTO
    public record GetOrderByIdQuery(Guid OrderId) : IRequest<OrderDto>;
}
