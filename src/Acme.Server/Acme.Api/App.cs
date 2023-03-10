using Acme.Api.Extensions;
using Acme.Core;
using Acme.Hosting;
using Acme.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Acme;

//TODO: Turn off implicit global usings.
public class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.Services.PopulateData();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public static void ConfigureJwt(IServiceCollection services, ConfigurationManager configuration)
    {
        var settings = configuration.GetJwtSettings();
        services.AddSingleton(settings);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "JwtBearer";
            options.DefaultChallengeScheme = "JwtBearer";
        })
        .AddJwtBearer("JwtBearer", jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(settings.AccessTokenSecret)),
                ValidateIssuer = true,
                ValidIssuer = settings.Issuer,

                ValidateAudience = true,
                ValidAudience = settings.Audience,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(10)
            };
        });


        //services
        //    .AddAuthentication()
        //    .AddJwtBearer(options =>
        //    {
        //        options.Audience = "https://localhost:5001";
        //options.TokenValidationParameters = new TokenValidationParameters
        //{
        //    ValidateIssuerSigningKey = true,
        //    IssuerSigningKey = new SymmetricSecurityKey(
        //        System.Text.Encoding.UTF8.GetBytes(jwtSettings.AccessTokenSecret)
        //    ),
        //    ValidateIssuer = true,
        //    ValidIssuer = jwtSettings.Issuer,
        //    ValidateAudience = true,
        //    ValidAudience = jwtSettings.Audience,
        //    ValidateLifetime = true,
        //    ClockSkew = TimeSpan.FromMinutes(jwtSettings.AccessTokenExpirationMinutes)
        //};
        // });

    }

    public static void ConfigureServices(
        IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.ConfigurePersistance(configuration.GetConnectionString("DefaultConnection"));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ISecurityService, SecurityService>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });
        services.AddRepositories();

        ConfigureJwt(services, configuration);

        services.AddControllers();

        services
            .AddIdentityCore<Acme.Core.Identity.User>()
            .AddRoles<Acme.Core.Identity.Role>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services
            .AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });
    }
}
