using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.Repositories.Brand;
using ThePreference.Infrastructure.Repository.Repositories.Category;

namespace ThePreference.Infrastructure.Repository.DependencyResolution;

public static class ServiceInitializer
{
    public static IConfiguration RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterCustomDependencies(services);
       
        RegisterDataContext(services, configuration);
        return configuration;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        services.AddScoped<ICommandCategoryRepository, CommandCategoryRepository>();
        services.AddScoped<IQueryCategoryRepository, QueryCategoryRepository>();
        
        services.AddScoped<ICommandBrandRepository, CommandBrandRepository>();
        services.AddScoped<IQueryBrandRepository, QueryBrandRepository>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    private static void RegisterDataContext(IServiceCollection services,IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<ProductContext>(options => options.UseSqlServer(connectionString));
    }
}