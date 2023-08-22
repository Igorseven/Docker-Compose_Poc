using CustomerBase.API.Business.ApplicationService.Interfaces.ServiceContracts;
using CustomerBase.API.Business.ApplicationService.Services.CustomerServices;

namespace CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerQueryService, CustomerQueryService>()
                .AddScoped<ICustomerCommandService, CustomerCommandService>();
}
