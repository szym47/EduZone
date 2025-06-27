using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Order.Domain.Models;

namespace Order.Domain.Interfaces
{
    public interface IOrderCreator
    {
        void CreateOrder(int userId, OrderItem product);
    }
}
