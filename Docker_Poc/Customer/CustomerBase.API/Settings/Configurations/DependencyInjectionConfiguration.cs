using CustomerBase.API.Business.Domain.Handlers.NotificationHandler;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
using CustomerBase.API.Business.Domain.Providers;
using CustomerBase.API.Business.Insfrastructure.ORM.Context;
using CustomerBase.API.Business.Insfrastructure.ORM.UoW;
using CustomerBase.API.Settings.Configurations.DependencyInjectionSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomerBase.API.Settings.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

        services.AddScoped<ApplicationContext>()
                .AddScoped<INotificationHandler, NotificationHandler>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
           options.UseSqlServer(serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection, sql => sql.CommandTimeout(180)));


        services.AddValidationDI()
                .AddRepositoryDI()
                .AddPaginationDI()
                .AddServiceDI()
                .AddEntityMapperDI();

        return services;
    }
}
