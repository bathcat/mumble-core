using Acme.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Web;

[ApiController]
[Route("[controller]")]
public class SnakesController : ControllerBase
{
    private readonly ISnakeService service;

    public SnakesController(ISnakeService service) => this.service = service;

    [HttpGet()]
    public Task<IEnumerable<SnakeInfo>> Get() => this.service.Get();

    [HttpGet("{id}")]
    public Task<SnakeInfo?> Get(Guid id) => this.service.Get(id);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPost()]
    public Task<SnakeInfo> Post(Snake value) => this.service.Create(value);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPut("{id}")]
    public Task<SnakeInfo> Put(Guid id, [FromBody] Snake value) => this.service.Update(value);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpDelete("{id}")]
    public Task<SnakeInfo?> Delete(Guid id) => this.service.Remove(id);
}
