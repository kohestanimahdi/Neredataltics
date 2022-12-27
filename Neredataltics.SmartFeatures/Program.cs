using Microsoft.EntityFrameworkCore;
using Neredataltics.SmartFeatures.Data;
using Neredataltics.SmartFeatures.Data.DataInitializers;
using Neredataltics.SmartFeatures.Data.Repositories;
using Neredataltics.SmartFeatures.Models.Options;
using Neredataltics.SmartFeatures.Services.WeatherServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseContext"));
});

builder.Services.Configure<SmartModelOptions>(builder.Configuration.GetSection("SmartModelOptions"));
builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddScoped<IWeatherConditionRepository, WeatherConditionRepository>();
builder.Services.AddScoped<IDataInitializer, WeatherConditionDataInitializer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetService<ApplicationDBContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
    catch
    {
    }
}
using (var scope = app.Services.CreateScope())
{
    var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
    foreach (var dataInitializer in dataInitializers)
        dataInitializer.Initialize();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
