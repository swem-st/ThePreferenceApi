using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThePreference.Infrastructure.Repository.DataAccess;

namespace ThePreference.Infrastructure.Repository.DependencyResolution;

public static class ServiceInitializer
{
    public static IConfiguration RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // RegisterCustomDependencies(services);
       
        RegisterDataContext(services, configuration);
        return configuration;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        //services.AddTransient<IChuckNorrisRespositoryAPI, ChuckNorrisRespositoryAPI>();
    }

    private static void RegisterDataContext(IServiceCollection services,IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddDbContext<PeopleContext>(options => options.UseSqlServer(connectionString));
    }
}