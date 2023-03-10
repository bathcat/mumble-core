using Acme.Core;
using Acme.Core.Extensions;

namespace Acme.Business;

public class SnakeService : ISnakeService
{
    private readonly IRepository<SnakeInfo, Guid> repo;

    public SnakeService(IRepository<SnakeInfo, Guid> repo) => this.repo = repo;

    public Task<SnakeInfo> Create(Snake original) =>
        this.repo.Create(original.ToSnakeInfo("Provisional"));

    public async Task<SnakeInfo> Update(Snake updated)
    {
        //TODO: This is kind of sleazy.
        var persisted = await this.repo.Get(updated.ID);

        if (persisted == null)
        {
            throw new Exception("That snake does not exist.");
        }

        var info = updated.ToSnakeInfo(persisted.PayGrade);
        return await this.repo.Update(info);
    }

    public Task<SnakeInfo?> Remove(Guid id) => this.repo.Remove(id);

    public Task<SnakeInfo?> Get(Guid id) => this.repo.Get(id);

    public Task<IEnumerable<SnakeInfo>> Get() => this.repo.Get();
}
