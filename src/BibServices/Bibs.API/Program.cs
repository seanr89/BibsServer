using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Bibs.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration["PostgreSQL:ConnectionString"];
builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample")
    .AddNpgSql(connectionString);

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



app.MapControllers();

app.Run();
