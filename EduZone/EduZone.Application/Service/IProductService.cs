using EduZoneDomain.Models;

namespace EduZone.Application.Service
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task<Product> AddAsync(Product product);
        Product Add(Product product);
    }
}
