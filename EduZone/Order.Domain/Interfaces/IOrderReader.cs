using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain.Models;

namespace Order.Domain.Interfaces
{
    public interface IOrderReader
    {
        Order.Domain.Models.Order GetOrder(int orderId);
        List<Order.Domain.Models.Order> GetAllOrders();
    }
}