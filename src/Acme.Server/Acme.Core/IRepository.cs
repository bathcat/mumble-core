using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Core;

public interface IRepository<Tmodel, Tid>
{
    Task<Tmodel?> Get(Tid id);

    Task<IEnumerable<Tmodel>> Get();

    // TODO: Consider adding this in as a better justification for building up sql strings.
    //IEnumerable<Tmodel> Get(IEnumerable<Tid> ids);



    Task<Tmodel> Create(Tmodel toCreate);

    Task<Tmodel> Update(Tmodel toUpdate);

    Task<Tmodel?> Remove(Tid id);
}
