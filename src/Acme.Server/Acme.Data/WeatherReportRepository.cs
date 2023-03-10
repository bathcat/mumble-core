using Acme.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Data;

public class WeatherReportRepository : IRepository<WeatherReport, Guid>
{
    private readonly AppDbContext context;

    public WeatherReportRepository(AppDbContext context) => this.context = context;

    private DbSet<WeatherReport> WeatherReports => this.context.WeatherReports!;

    public async Task<WeatherReport> Create(WeatherReport original)
    {
        var result = await this.WeatherReports.AddAsync(original);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<WeatherReport> Update(WeatherReport updated)
    {
        var persisted = this.WeatherReports.Update(updated);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public async Task<WeatherReport?> Remove(Guid id)
    {
        var original = await this.WeatherReports.SingleOrDefaultAsync(r => r.ID == id);
        if (original == null)
        {
            return null;
        }

        var persisted = this.WeatherReports.Remove(original);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public Task<WeatherReport?> Get(Guid id) =>
        this.WeatherReports.SingleOrDefaultAsync(r => r.ID == id);

    public async Task<IEnumerable<WeatherReport>> Get()
    {
        var results = await this.WeatherReports.ToListAsync();
        return results;
    }
}
