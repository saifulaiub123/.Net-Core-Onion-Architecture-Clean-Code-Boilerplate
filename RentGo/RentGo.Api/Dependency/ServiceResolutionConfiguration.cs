using RentGo.Application.IService;
using RentGo.Framework;
using RentGo.Service.CoreService;

namespace RentGo.Api.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOtpService, OtpService>();




            services.AddScoped<ISmsHelper, SmsHelper>();
            return services;
        }
    }
}
