using EduZoneDomain.Models;

public interface IRepository
{
    #region Product
    Task<Product> GetProductAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);  // Dodaj tę metodę
    Task<List<Product>> GetAllProductAsync();
    #endregion

}
