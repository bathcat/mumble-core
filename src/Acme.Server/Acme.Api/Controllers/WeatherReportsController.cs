using Acme.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Web;

[ApiController]
[Route("[controller]")]
public class WeatherReportsController : ControllerBase
{
    private readonly IRepository<WeatherReport, Guid> service;

    public WeatherReportsController(IRepository<WeatherReport, Guid> service)
    {
        this.service = service;
    }

    [HttpGet()]
    public Task<IEnumerable<WeatherReport>> Get() => this.service.Get();

    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPost()]
    public Task<WeatherReport> Post(WeatherReport value) => this.service.Create(value);

    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpPut("{id}")]
    public Task<WeatherReport> Put(Guid id, [FromBody] WeatherReport value) =>
        this.service.Update(value);

    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [HttpDelete("{id}")]
    public Task<WeatherReport?> Delete(Guid id) => this.service.Remove(id);
}
