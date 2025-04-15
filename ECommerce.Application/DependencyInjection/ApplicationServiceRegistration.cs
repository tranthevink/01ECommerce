using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using ECommerce.Application.Common.ScanMediatR;

namespace ECommerce.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(MediatorEntryPoint).Assembly));
            return services;
        }
    }
}
