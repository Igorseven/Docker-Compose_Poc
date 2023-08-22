using CustomerBase.API.Settings;
using CustomerBase.API.Settings.Configurations;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


builder.Services.AddSettingsConfigurations(configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DfPolicy");
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.Run();
