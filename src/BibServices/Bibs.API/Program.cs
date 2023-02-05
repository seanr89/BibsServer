using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Bibs.API.Extensions;
using Application;
using Infrastructure;
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
// builder.Services.AddApplication();
// builder.Services.AddInfrastructure(configuration);

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");
builder.Services.AddHealthChecksUI(setup =>
    {
        setup.SetHeaderText("Storage providers demo");
        //Maximum history entries by endpoint
        setup.MaximumHistoryEntriesPerEndpoint(50);
        //One endpoint is configured in appsettings, let's add another one programatically
        setup.AddHealthCheckEndpoint("Endpoint2", "/random-health");
    })
    .AddInMemoryStorage();

//NB. Ensure no services are injected after this!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// else
// {
//     // app.UseHttpsRedirection();
//     // app.UseAuthorization();
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


app
.UseRouting()
.UseEndpoints(config => {
    //config.MapControllers();
    //config.MapHealthChecksUI();
    config.MapHealthChecks("/healthz", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    // config.MapHealthChecksUI(setup =>
    //     {
    //         setup.UIPath = "/show-health-ui"; // this is ui path in your browser
    //         setup.ApiPath = "/health-ui-api"; // the UI ( spa app )  use this path to get information from the store ( this is NOT the healthz path, is internal ui api )
    //         setup.PageTitle = "My wonderful Health Checks UI"; // the page title in <head>
    //     });
    }
); 
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");
// healthchecks-ui

// app.MapControllers();

app.Run();
