using System.Collections.Generic;

namespace MC.Snakes.Core;

public interface IRepository<Tmodel, Tid>
{
    Tmodel Get(Tid id);

    IEnumerable<Tmodel> Get();

    Tmodel Create(Tmodel toCreate);

    Tmodel Update(Tmodel toUpdate);

    Tmodel Remove(Tid id);

}
