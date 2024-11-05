using Domain.Interfaces.Repositories;
using Infrastructure.Persistences.Databases;
using Infrastructure.Persistences.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServicesRegistration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbManagement>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();

            return services;
        }
    }
}
