using MC.Snakes.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MC.Snakes.Data;

public class SnakeRepository : IRepository<Snake, Guid>
{
    private readonly AppDbContext context;

    public SnakeRepository(AppDbContext context) => this.context = context;

    private DbSet<Snake> Snakes => this.context.Snakes!;

    private DatabaseFacade Database => this.context.Database!;

    ///////  Create  /////////




    public async Task<Snake> Create(Snake original)
    {
        var result = await this.Snakes.AddAsync(original);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }


    public async Task<Snake> Update(Snake updated)
    {
        var persisted = this.Snakes.Update(updated);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public async Task<Snake?> Remove(Guid id)
    {
        var original = await this.Snakes.SingleOrDefaultAsync(r => r.ID == id);
        if (original == null)
        {
            return null;
        }

        var persisted = this.Snakes.Remove(original);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public Task<Snake?> Get(Guid id) => this.Snakes.SingleOrDefaultAsync(r => r.ID == id);

    public async Task<IEnumerable<Snake>> Get()
    {
        var results = await this.Snakes.ToListAsync();
        return results;
    }
}
