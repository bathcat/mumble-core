using Acme.Business;
using Acme.Core;
using Acme.Data;
using Acme.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acme.Hosting;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<WeatherReport, Guid>, WeatherReportRepository>();
        services.AddTransient<IRepository<Beverage, Guid>, BeverageRepository>();
        services.AddTransient<IRepository<SnakeInfo, Guid>, SnakeRepository>();
        services.AddTransient<ISnakeService, SnakeService>();
    }

    public static void ConfigurePersistance(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.ConfigureAppDbContext(connectionString);
        services.ConfigureIdentityDbContext(connectionString);
    }

    public static void ConfigureAppDbContext(
        this IServiceCollection services,
        string connectionString
    ) => services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

    public static void ConfigureIdentityDbContext(
        this IServiceCollection services,
        string connectionString
    ) =>
        services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString));
}
