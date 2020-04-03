using PM.Api.Domain.Contracts.Repositories;
using PM.Api.Infra.Data.Connections;
using PM.Api.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace PM.Api.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnection, SqlServerConnection>();
            services.AddSingleton<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
