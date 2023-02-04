using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Bibs.API.Extensions;
using Application;
using Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PostgreSettings>(
                builder.Configuration.GetSection("PostgreSQL"));

//Injected application logic!
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];
// builder.Services.AddHealthChecks()
//     .AddCheck<SampleHealthCheck>("Sample", failureStatus: HealthStatus.Unhealthy);
// builder.Services.AddHealthChecksUI(setup => 
//     setup.SetEvaluationTimeInSeconds(45)
//     // Set the maximum history entries by endpoint that will be served by the UI api middleware
//     .MaximumHistoryEntriesPerEndpoint(25)
//     .AddHealthCheckEndpoint("default api", "/home"))
//     .AddInMemoryStorage();

//NB. Ensure no services are injected after this!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // app.UseHttpsRedirection();
    // app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");
app
.UseRouting()
.UseEndpoints(config => {
    config.MapControllers();
    // config.MapHealthChecks("/hc", new HealthCheckOptions()
    //         {
    //             Predicate = _ => true,
    //             ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    //         });
    // config.MapHealthChecksUI();
    }
); //healthchecks-ui


app.Run();
