using Microsoft.Extensions.DependencyInjection;
using RentGo.Application.IService;
using RentGo.Application.Service;

namespace RentGo.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOtpService, OtpService>();
            return services;
        }
    }
}
