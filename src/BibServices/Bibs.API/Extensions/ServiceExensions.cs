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

    public static void ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
    }
}
