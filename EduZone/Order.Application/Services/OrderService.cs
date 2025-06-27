using System.Collections.Generic;
using System.Linq;
using Order.Domain.Interfaces;
using Order.Domain.Models;
using Order.Infrastructure.Repositories;

namespace Order.Domain.Services
{
    public class OrderService : IOrderCreator, IOrderCanceler, IOrderReader
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        // Tworzy nowe zamówienie z pojedynczym produktem
        public void CreateOrder(int userId, OrderItem product)
        {
            var order = new Order.Domain.Models.Order
            {
                UserId = userId
            };
            order.Products.Add(product);
            _repository.Add(order);
        }

        // Anuluje (aktualizuje) istniejące zamówienie
        public void CancelOrder(int orderId)
        {
            var order = _repository.FindById(orderId);
            if (order != null)
            {
                order.Products.Clear();
                _repository.Update(order);
            }
        }

        // Zwraca pojedyncze zamówienie
        public Order.Domain.Models.Order GetOrder(int orderId)
        {
            var o = _repository.FindById(orderId);
            if (o == null) return null;

            return new Order.Domain.Models.Order
            {
                Id = o.Id,
                UserId = o.UserId,
                Products = o.Products
                               .Select(p => new OrderItem { ProductId = p.ProductId })
                               .ToList()
            };
        }

        // Zwraca wszystkie zamówienia
        public List<Order.Domain.Models.Order> GetAllOrders()
        {
            return _repository.GetAll().Select(o => new Order.Domain.Models.Order
                              {
                                  Id = o.Id,
                                  UserId = o.UserId,
                                  Products = o.Products
                                                 .Select(p => new OrderItem { ProductId = p.ProductId })
                                                 .ToList()
                              })
                              .ToList();
        }
    }
}
