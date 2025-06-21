using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCart.Domain.Models;

namespace ShoppingCart.Infrastructure.Repositories
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly List<Cart> _carts = new();

        public void Add(Cart cart) => _carts.Add(cart);

        public void Update(Cart cart)
        {
            var existingCart = _carts.FirstOrDefault(c => c.Id == cart.Id);
            if (existingCart != null)
            {
                existingCart.Products = cart.Products;
            }
        }

        public Cart FindById(int id) => _carts.FirstOrDefault(c => c.Id == id);

        public List<Cart> GetAll() => _carts.ToList();
    }
}