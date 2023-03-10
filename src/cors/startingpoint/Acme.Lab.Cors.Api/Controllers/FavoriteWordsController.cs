using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acme.Lab.Cors.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class FavoriteWordsController : ControllerBase
{
    private readonly IFavoriteWordsService service;
    public FavoriteWordsController(IFavoriteWordsService service)
    {
        this.service = service;
    }


    [HttpGet]
    public IEnumerable<string> Get()
    {
        return this.service.Get();
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
        this.service.Add(value);
    }

    [HttpDelete("{word}")]
    public void Delete(string word)
    {
        this.service.Remove(word);
    }
}
