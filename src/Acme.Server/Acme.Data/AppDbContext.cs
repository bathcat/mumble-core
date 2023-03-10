using Acme.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Acme.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<WeatherReport>? WeatherReports { get; set; }

    public DbSet<Beverage>? Beverages { get; set; }
    public DbSet<SnakeInfo>? Snakes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("App");

        builder.Entity<SnakeInfo>(b =>
        {
            b.ToTable(nameof(SnakeInfo));
        });

        builder.Entity<Beverage>(b =>
        {
            b.ToTable(nameof(Beverage));
        });

        builder.Entity<WeatherReport>(b =>
        {
            b.ToTable(nameof(WeatherReport));
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder ob)
    {
        ob.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}

/// <summary>
/// Note: this is only to get Visual Studio scaffolding to work. It should never
/// be needed at runtime.
///
/// TODO: Put a pragma here or something.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(
            "Data Source=.\\SQLEXPRESS;Initial Catalog=acme;Integrated Security=SSPI;"
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}
