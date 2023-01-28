using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Bibs.API.Extensions;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injected application logic!
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];
builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");
builder.Services.AddHealthChecksUI().AddInMemoryStorage();
    //.AddNpgSql(connectionString);

//NB. Ensure no Services are injected after this!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.MapHealthChecks("/healthcheck", new HealthCheckOptions());
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");


app.MapControllers();

app.Run();
