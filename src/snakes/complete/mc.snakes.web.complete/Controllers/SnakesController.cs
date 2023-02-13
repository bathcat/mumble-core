using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Acme.Snakes.Core;
using Microsoft.Extensions.Logging;

namespace Acme.Snakes.Web.Controllers
{
    [Route("api/[controller]")]
    public class SnakesController : Controller
    {
        private readonly IRepository<Snake, Guid> repo;
        private readonly ILogger<SnakesController> logger;

        public SnakesController(IRepository<Snake,Guid> repo, ILogger<SnakesController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Snake> Get()
        {
            this.logger.LogInformation("Getting all snakes. Hopefully there aren't too many...");
            return this.repo.Get();
        }
            

        [HttpGet("{id}")]
        public Snake Get(Guid id)
            => this.repo.Get(id);

        [HttpPost]
        public Snake Post([FromBody]Snake newSnake)
            => this.repo.Create(newSnake);

        [HttpPut("{id}")]
        public Snake Put(Guid id, [FromBody]Snake updated)
        {
            if (updated.ID != id)
            {
                this.logger.LogWarning("Weird put. It's probably ok though.");
                updated.ID = id;
            }
            return this.repo.Update(updated);
        }
            

        [HttpDelete("{id}")]
        public Snake Delete(Guid id)
            => this.repo.Remove(id);
    }
}
