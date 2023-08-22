using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.EntitiesValidation;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;

namespace CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;

public static class ValidationDI
{
    public static IServiceCollection AddValidationDI(this IServiceCollection services) => 
        services.AddScoped<IValidate<Address>, AddressValidation>()
                .AddScoped<IValidate<EmailAddress>, EmailAddressValidation>()
                .AddScoped<IValidate<Telephone>, TelephoneValidation>()
                .AddScoped<IValidate<Customer>, CustomerValidation>();
}
