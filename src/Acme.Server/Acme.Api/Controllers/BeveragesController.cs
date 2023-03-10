using Acme.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Web;

[ApiController]
[Route("[controller]")]
public class BeveragesController : ControllerBase
{
    private readonly IRepository<Beverage, Guid> service;

    public BeveragesController(IRepository<Beverage, Guid> service)
    {
        this.service = service;
    }

    [HttpGet()]
    public Task<IEnumerable<Beverage>> Get() => this.service.Get();

    [HttpGet("{id}")]
    public Task<Beverage?> Get(Guid id) => this.service.Get(id);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPost()]
    public Task<Beverage> Post(Beverage value) => this.service.Create(value);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPut("{id}")]
    public Task<Beverage> Put(Guid id, [FromBody] Beverage value) => this.service.Update(value);

    //[Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpDelete("{id}")]
    public Task<Beverage?> Delete(Guid id) => this.service.Remove(id);
}
