using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
using CustomerBase.API.Business.Insfrastructure.Repository;

namespace CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerRepository, CustomerRepository>();
}
