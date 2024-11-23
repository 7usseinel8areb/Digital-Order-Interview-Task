using DigitalOrder.Infrastructure.Abstracts;
using DigitalOrder.Infrastructure.InfrastructureBases.Abstract;
using DigitalOrder.Infrastructure.InfrastructureBases.Implementation;
using DigitalOrder.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalOrder.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
