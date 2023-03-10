using Acme.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Acme;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.Services.PopulateData();
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    public static void ConfigureServices(
        IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.ConfigurePersistance(configuration.GetConnectionString("DefaultConnection"));
        services.AddRepositories();

        services.Configure<IdentityOptions>(options => { });

        services.AddMvc();

        services
            .AddIdentityCore<Acme.Core.Identity.User>()
            .AddRoles<Acme.Core.Identity.Role>()
            .AddEntityFrameworkStores<Acme.Identity.IdentityDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services
            .AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });

        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        services.AddControllersWithViews();
    }
}
