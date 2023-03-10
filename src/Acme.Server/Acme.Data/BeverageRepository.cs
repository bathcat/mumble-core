using Acme.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Data;

public class BeverageRepository : IRepository<Beverage, Guid>
{
    private readonly AppDbContext context;

    public BeverageRepository(AppDbContext context) => this.context = context;

    private DbSet<Beverage> Beverages => this.context.Beverages!;

    public async Task<Beverage> Create(Beverage original)
    {
        var result = await this.Beverages.AddAsync(original);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Beverage> Update(Beverage original)
    {
        var persisted = this.Beverages.Update(original);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public async Task<Beverage?> Remove(Guid id)
    {
        var original = await this.Beverages.SingleOrDefaultAsync(r => r.ID == id);
        if (original == null)
        {
            return null;
        }

        var persisted = this.Beverages.Remove(original);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public Task<Beverage?> Get(Guid id) => this.Beverages.SingleOrDefaultAsync(r => r.ID == id);

    public async Task<IEnumerable<Beverage>> Get()
    {
        var results = await this.Beverages.ToListAsync();
        return results;
    }
}
