using MC.Snakes.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.Snakes.Web.Controllers;

[Route("api/[controller]")]
public class SnakesController : Controller
{
    private readonly IRepository<Snake, Guid> repo;
    private readonly ILogger<SnakesController> logger;

    public SnakesController(IRepository<Snake, Guid> repo, ILogger<SnakesController> logger)
    {
        this.repo = repo;
        this.logger = logger;
    }

    [HttpGet]
    public Task<IEnumerable<Snake>> Get()
    {
        this.logger.LogInformation("Getting all snakes. Hopefully there aren't too many...");
        return this.repo.Get();
    }


    [HttpGet("{id}")]
    public Task<Snake> Get(Guid id)
        => this.repo.Get(id);

    [HttpPost]
    public Task<Snake> Post([FromBody] Snake newSnake)
        => this.repo.Create(newSnake);

    [HttpPut("{id}")]
    public Task<Snake> Put(Guid id, [FromBody] Snake updated)
    {
        if (updated.ID != id)
        {
            this.logger.LogWarning("Weird put. It's probably ok though.");
            updated.ID = id;
        }
        return this.repo.Update(updated);
    }


    [HttpDelete("{id}")]
    public Task<Snake> Delete(Guid id)
        => this.repo.Remove(id);
}
