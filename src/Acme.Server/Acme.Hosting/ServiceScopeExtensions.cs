using Acme.Data;
using Acme.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Acme.Hosting;

public static class ServiceScopeExtensions
{
    public static async Task PopulateBusinessData(this IServiceScope scope)
    {
        using var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();

        if (appDbContext == null)
        {
            throw new Exception("Can't find dbcontext.");
        }

        var appBootstrapper = new AppDataBootstrapper(appDbContext);
        await appBootstrapper.Seed();
    }

    public static async Task PopulateIdentityData(this IServiceScope scope)
    {
        using var roleManager = scope.ServiceProvider.GetService<
            RoleManager<Acme.Core.Identity.Role>
        >();
        using var userManager = scope.ServiceProvider.GetService<
            UserManager<Acme.Core.Identity.User>
        >();
        using var idDbContext = scope.ServiceProvider.GetService<IdentityDbContext>();
        var idDbBootstrapper = new IdentityBootstrapper(roleManager!, userManager!, idDbContext!);
        await idDbBootstrapper.Seed();
    }
}
