using Acme.Snakes.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Snakes.Business
{
    public class SnakeJar : IRepository<Snake, Guid>
    {

        private List<Snake> residents = new List<Snake>
        {
            new Snake{ID=Guid.NewGuid(), Name="Sally", MeannessLevel=12},
            new Snake{ID=Guid.NewGuid(), Name="Sergio", MeannessLevel=7800},
            new Snake{ID=Guid.NewGuid(), Name="Samuel", MeannessLevel=6},
            new Snake{ID=Guid.NewGuid(), Name="Sarah", MeannessLevel=8999},
        };


        public Snake Create(Snake toCreate)
        {
            if (toCreate.ID != Guid.Empty)
            {
                throw new ArgumentException("Snake already exists!");
            }
            toCreate.ID = Guid.NewGuid();
            this.residents.Add(toCreate);
            return toCreate;
        }

        public Snake Get(Guid id)
            => this.residents.FirstOrDefault(s => s.ID == id);

        public IEnumerable<Snake> Get()
            => this.residents;

        public Snake Remove(Guid id)
        {
            var removed = this.residents.FirstOrDefault(s => s.ID == id);

            if (removed != null)
            {
                this.residents = this.residents
                                     .Where(s => s.ID != id)
                                     .ToList();
            }

            return removed;
        }

        public Snake Update(Snake toUpdate)
        {
            this.residents = this.residents
                                 .Where(s => s.ID != toUpdate.ID)
                                 .Prepend(toUpdate)
                                 .ToList();
            return toUpdate;
        }
    }
}
