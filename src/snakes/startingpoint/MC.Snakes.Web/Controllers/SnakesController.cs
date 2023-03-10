using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MC.Snakes.Web.Controllers;

[Route("api/[controller]")]
public class SnakesController : Controller
{


    public SnakesController()
    {

    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Sven", "Steven", "Sandy" };
    }

}
