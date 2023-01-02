using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Contexts;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection servicesIConfiguration configuration)
    {
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlServer(configuration.GetValue<string>("ConnectionSettings:DefaultConnection")));
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("PostgreSQL:ConnectionString")));

        return services;
    }
}