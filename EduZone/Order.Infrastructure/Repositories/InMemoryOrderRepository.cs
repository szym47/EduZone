using System.Collections.Generic;
using System.Linq;
using Order.Domain.Interfaces;
using Order.Domain.Models;

namespace Order.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order.Domain.Models.Order> _orders = new();
        private int _nextId = 1;

        public void Add(Order.Domain.Models.Order order)
        {
            order.Id = _nextId++;
            _orders.Add(order);
        }

        public void Update(Order.Domain.Models.Order order)
        {
            var idx = _orders.FindIndex(o => o.Id == order.Id);
            if (idx >= 0)
                _orders[idx] = order;
        }

        public Order.Domain.Models.Order FindById(int id)
            => _orders.FirstOrDefault(o => o.Id == id);

        public List<Order.Domain.Models.Order> GetAll()
            => _orders.ToList();
    }
}
