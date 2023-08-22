using CustomerBase.API.Settings.Configurations;

namespace CustomerBase.API.Settings;

public static class SettingsHandler
{
    public static IServiceCollection AddSettingsConfigurations(this IServiceCollection services, IConfiguration configuration) =>
        services.AddControllersConfiguration()
                .AddFiltersConfiguration()
                .AddCorsConfiguration()
                .AddSwaggerConfiguration()
                .AddDependencyInjectionConfiguration(configuration);
}
