using Acme.Core;
using Acme.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Hosting;

public class AppDataBootstrapper
{
    private readonly AppDbContext context;

    public AppDataBootstrapper(AppDbContext dbContext) => this.context = dbContext;

    public async Task Seed()
    {
        await this.context.EnsureSchema();

        if (this.context.Snakes!.Any())
        {
            //This means we've already run things.
            return;
        }
        await this.context.Beverages!.AddRangeAsync(GetSeedBeverages());
        await this.context.Snakes!.AddRangeAsync(GetSeedSnakes());
        await this.context.WeatherReports!.AddRangeAsync(GetSeedWeatherReports());

        var _ = await this.context.SaveChangesAsync();
    }

    public static IEnumerable<SnakeInfo> GetSeedSnakes()
    {
        yield return new SnakeInfo
        {
            ID = Guid.Parse("00000000-0000-0000-0000-100000000000"),
            Name = "Sally",
            Color = "Green",
            MeannessLevel = 15,
            PayGrade = "E6",
        };
        yield return new SnakeInfo
        {
            ID = Guid.Parse("00000000-0000-0000-0000-200000000000"),
            Name = "Sergio",
            Color = "Black",
            MeannessLevel = 8,
            PayGrade = "E8",
        };
        yield return new SnakeInfo
        {
            ID = Guid.Parse("00000000-0000-0000-0000-300000000000"),
            Name = "Sylvester",
            Color = "Striped",
            MeannessLevel = 75,
            PayGrade = "E12",
        };
    }

    public static IEnumerable<WeatherReport> GetSeedWeatherReports()
    {
        yield return new WeatherReport
        {
            Date = DateTime.Parse("2021-12-29"),
            Summary = "hot",
            Temperature = 35,
            ID = Guid.NewGuid()
        };
        yield return new WeatherReport
        {
            Date = DateTime.Parse("2021-12-30"),
            Summary = "breezy",
            Temperature = 30,
            ID = Guid.NewGuid()
        };
        yield return new WeatherReport
        {
            Date = DateTime.Parse("2021-12-31"),
            Summary = "warm",
            Temperature = 25,
            ID = Guid.NewGuid()
        };
        yield return new WeatherReport
        {
            Date = DateTime.Parse("2022-01-01"),
            Summary = "rainy",
            Temperature = 20,
            ID = Guid.NewGuid()
        };
    }

    public static IEnumerable<Beverage> GetSeedBeverages()
    {
        yield return new Beverage
        {
            ID = Guid.NewGuid(),
            Name = "White Russian",
            Description = "Cream, etc.",
        };
        yield return new Beverage
        {
            ID = Guid.NewGuid(),
            Name = "Duff",
            Description = "Simpsons beer.",
        };
    }
}
