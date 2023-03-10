using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Lab.Cors.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IFavoriteWordsService, FavoriteWordService>();
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.WithMethods("GET");
                policy.AllowAnyOrigin();
            });

            options.AddPolicy("Only-Acme-Apps", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.SetIsOriginAllowed(o => o == "https://localhost:7009");
            });
        });

        var app = builder.Build();
        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}
