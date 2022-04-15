using RentGo.Application.IRepository;
using RentGo.Infrastructure.Repository;

namespace RentGo.Api.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOtpRepository, OtpRepository>();
            return services;
        }
    }
}
