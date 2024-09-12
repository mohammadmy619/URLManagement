

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<UrlManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("UrlManagementDbContext"));
        });

        services.AddScoped<IUrlRepository, UrlRepository>();


        return services;
    }
}