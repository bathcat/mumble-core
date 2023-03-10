using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Core;

public interface ISnakeService
{
    Task<SnakeInfo> Create(Snake original);
    Task<IEnumerable<SnakeInfo>> Get();
    Task<SnakeInfo?> Get(Guid id);
    Task<SnakeInfo?> Remove(Guid id);
    Task<SnakeInfo> Update(Snake updated);
}
