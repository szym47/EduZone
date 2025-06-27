using System;
using System.Collections.Generic;
using Order.Domain.Models;

namespace Order.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order.Domain.Models.Order order);
        void Update(Order.Domain.Models.Order order);
        Order.Domain.Models.Order FindById(int id);
        List<Order.Domain.Models.Order> GetAll();
    }
}
