using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.Repositories.Brand;
using ThePreference.Infrastructure.Repository.Repositories.Category;
using ThePreference.Infrastructure.Repository.Repositories.Color;
using ThePreference.Infrastructure.Repository.Repositories.Image;
using ThePreference.Infrastructure.Repository.Repositories.Product;

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
        
        services.AddScoped<ICommandColorRepository, CommandColorRepository>();
        services.AddScoped<IQueryColorRepository, QueryColorRepository>();
        
        services.AddScoped<ICommandImageRepository, CommandImageRepository>();
        services.AddScoped<IQueryImageRepository, QueryImageRepository>();
        
        services.AddScoped<ICommandProductRepository, CommandProductRepository>();
        services.AddScoped<IQueryProductRepository, QueryProductRepository>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    private static void RegisterDataContext(IServiceCollection services,IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContextPool<ProductContext>(options => options.UseSqlServer(connectionString));
    }
}