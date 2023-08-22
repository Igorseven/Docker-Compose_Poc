using CustomerBase.API.Business.Insfrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerBase.API.Settings.Configurations;

public static class MigrationHandlerConfiguration
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception)
            {
                throw;
            }
        }
        return webApp;
    }
}
