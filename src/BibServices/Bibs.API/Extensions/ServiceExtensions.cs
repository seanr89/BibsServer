using Infrastructure;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bibs.API.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy($"{configuration["Cors:PolicyName"]}",
                builder => builder.WithOrigins($"{configuration["Cors:Origin"]}")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
        });
        //builder => builder.AllowAnyOrigin()
    }

    /// <summary>
    /// Setup EFCore DB and Seed any data if necessary
    /// </summary>
    /// <param name="services"></param>
    public static void RunDBMigration(IServiceCollection services)
    {
        try{
            var provider = services.BuildServiceProvider();
            var context = provider.GetRequiredService<AppDbContext>();
            var opt = provider.GetRequiredService<IOptions<PostgreSettings>>().Value;
    
            if(opt.Migrate)
                context.Database.Migrate();
            
            if(opt.SeedData)
                DbSeeding.TryRunSeed(context).Wait();
            
        }
        catch(Exception e)
        {
            Console.WriteLine($"Exception caught: {e.Message}");
        }
    }
}
