using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Contexts;
using Infrastructure.Repos;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlServer(configuration.GetValue<string>("ConnectionSettings:DefaultConnection")));
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("PostgreSQL:ConnectionString")));

        services.AddTransient<IClubsRepository, ClubsRepository>();
        return services;
    }
}