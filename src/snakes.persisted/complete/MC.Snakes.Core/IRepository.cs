using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.Snakes.Core;

public interface IRepository<Tmodel, Tid>
{
    Task<Tmodel> Get(Tid id);

    Task<IEnumerable<Tmodel>> Get();

    Task<Tmodel> Create(Tmodel toCreate);

    Task<Tmodel> Update(Tmodel toUpdate);

    Task<Tmodel> Remove(Tid id);

}
