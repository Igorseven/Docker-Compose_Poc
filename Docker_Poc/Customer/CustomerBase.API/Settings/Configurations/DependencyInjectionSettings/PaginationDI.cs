using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
using CustomerBase.API.Business.Insfrastructure.Services;

namespace CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;

public static class PaginationDI
{
    public static IServiceCollection AddPaginationDI(this IServiceCollection services) =>
        services.AddScoped<IPaginationQueryService<Customer>, PaginationQueryService<Customer>>();
}
