using DigitalOrder.Core.Entities;

namespace DigitalOrder.Service.Abstracts
{
    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(int id);

        Task<List<Product>> GetAllProductsAsync();

        Task<bool> AddProductAsync(Product product);

        Task<bool> DeleteProductAsync(Product product);

        Task<bool> EditProductAsync(Product product);

        Task<bool> IsProductNameExists(string name, int? id = 0);



    }
}
