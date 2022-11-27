using Microsoft.Extensions.DependencyInjection;
using RentGo.Domain.IRepository;
using RentGo.Infrastructure.Repository;

namespace RentGo.Infrastructure.Dependency
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
