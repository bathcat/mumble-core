using MC.Snakes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.Snakes.Business;

public class SnakeJar : IRepository<Snake, Guid>
{

    private List<Snake> residents = new List<Snake>
        {
            new Snake{ID=Guid.NewGuid(), Name="Sally", MeannessLevel=12},
            new Snake{ID=Guid.NewGuid(), Name="Sergio", MeannessLevel=7800},
            new Snake{ID=Guid.NewGuid(), Name="Samuel", MeannessLevel=6},
            new Snake{ID=Guid.NewGuid(), Name="Sarah", MeannessLevel=8999},
        };


    public Task<Snake> Create(Snake toCreate)
    {
        if (toCreate.ID != Guid.Empty)
        {
            throw new ArgumentException("Snake already exists!");
        }
        toCreate.ID = Guid.NewGuid();
        this.residents.Add(toCreate);
        return Task.FromResult(toCreate);
    }

    public Task<Snake> Get(Guid id)
        => Task.FromResult(this.residents.FirstOrDefault(s => s.ID == id));

    public Task<IEnumerable<Snake>> Get()
        => Task.FromResult(this.residents.AsEnumerable());

    public Task<Snake> Remove(Guid id)
    {
        var removed = this.residents.FirstOrDefault(s => s.ID == id);

        if (removed != null)
        {
            this.residents = this.residents
                                 .Where(s => s.ID != id)
                                 .ToList();
        }

        return Task.FromResult(removed);
    }

    public Task<Snake> Update(Snake toUpdate)
    {
        this.residents = this.residents
                             .Where(s => s.ID != toUpdate.ID)
                             .Prepend(toUpdate)
                             .ToList();
        return Task.FromResult(toUpdate);
    }
}

