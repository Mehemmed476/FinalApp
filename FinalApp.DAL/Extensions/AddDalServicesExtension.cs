using FinalApp.DAL.Contexts;
using FinalApp.DAL.Helpers;
using FinalApp.DAL.Repositories.Abstractions;
using FinalApp.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalApp.DAL.Extensions;

public static class AddDalServicesExtension
{
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddDbContext<FinalAppDbContext>(
            opt =>
            {
                opt.UseSqlServer(ConnectionStr.GetConnectionString());
            }
        );

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
    }
}