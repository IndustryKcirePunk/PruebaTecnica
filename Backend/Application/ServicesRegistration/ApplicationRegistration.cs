using Application.Handlers.Employee;
using Application.Handlers.Entity;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Query;
using Domain.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServicesRegistration
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(typeof(ApplicationRegistration).Assembly);
            });


            TypeAdapterConfig<CreateEmployeeCommand, Employee>.NewConfig();
            TypeAdapterConfig<UpdateEmployeeCommand, Employee>.NewConfig();

            TypeAdapterConfig<CreateEntityCommand, Entity>.NewConfig();
            TypeAdapterConfig<UpdateEntityCommand, Entity>.NewConfig();
            TypeAdapterConfig<Entity, CatalogEntityResponseQuery>
                .NewConfig()
                .Map(dest => dest.id, src => src.EntityId)
                .Map(dest => dest.name, src => src.Name);

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEntityService, EntityService>();

            return services;
        }
    }
}
