using RentGo.Api.Authentication;
using RentGo.Application.IService;

namespace RentGo.Api.Dependency
{
    public static class applicationResolutionConfiguration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenHelper>();
            services.AddScoped<IUserContext, UserContext>();
            return services;
        }
    }
}
