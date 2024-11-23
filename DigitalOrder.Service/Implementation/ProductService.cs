using DigitalOrder.Core.Entities;
using DigitalOrder.Infrastructure.Abstracts;
using DigitalOrder.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalOrder.Service.Implementation
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var trans = _productRepository.BeginTransaction();

            try
            {
                var deleted = await _productRepository.AddAsync(product);
                await trans.CommitAsync();
                return deleted;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return false;
            }

        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            return await _productRepository.DeleteAsync(product);
        }

        public async Task<bool> EditProductAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetTableNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsProductNameExists(string name, int? id)
        {
            var nameRepeated = await _productRepository.GetTableNoTracking()
                .Where(x => x.Name == name && (id == null || x.Id != id))
                .FirstOrDefaultAsync();

            return nameRepeated != null;
        }
    }
}
