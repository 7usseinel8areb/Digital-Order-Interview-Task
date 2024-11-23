using DigitalOrder.Core.Entities;
using DigitalOrder.Infrastructure.Abstracts;
using DigitalOrder.Infrastructure.Data;
using DigitalOrder.Infrastructure.InfrastructureBases.Implementation;
using Microsoft.EntityFrameworkCore;

namespace DigitalOrder.Infrastructure.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _products = context.Set<Product>();
        }

    }
}
