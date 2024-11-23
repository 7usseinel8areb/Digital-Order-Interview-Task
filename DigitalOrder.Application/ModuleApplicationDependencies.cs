using DigitalOrder.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DigitalOrder.Application
{
    public static class ModuleApplicationDependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Configuration of FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
