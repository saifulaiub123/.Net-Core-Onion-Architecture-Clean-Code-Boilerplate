using RentGo.Api.Authentication;

namespace RentGo.Api.Dependency
{
    public static class applicationResolutionConfiguration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<JWTExtensions>();
            return services;
        }
    }
}
