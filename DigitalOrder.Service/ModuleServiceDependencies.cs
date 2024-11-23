using DigitalOrder.Service.Abstracts;
using DigitalOrder.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalOrder.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
