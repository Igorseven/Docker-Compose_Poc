using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Mappers;

namespace CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;

public static class EntityMapperDI
{
    public static IServiceCollection AddEntityMapperDI(this IServiceCollection services) =>
        services.AddScoped<ICustomerMapper, CustomerMapper>()
                .AddScoped<IEmailAddressMapper, EmailAddressMapper>()
                .AddScoped<ITelephoneMapper, TelephoneMapper>()
                .AddScoped<IAddressMapper, AddressMapper>();
        
}
