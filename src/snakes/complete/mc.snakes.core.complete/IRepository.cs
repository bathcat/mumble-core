using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Snakes.Core
{
    public interface IRepository<Tmodel,Tid>
    {
        Tmodel Get(Tid id);

        IEnumerable<Tmodel> Get();

        Tmodel Create(Tmodel toCreate);

        Tmodel Update(Tmodel toUpdate);

        Tmodel Remove(Tid id);

    }
}
