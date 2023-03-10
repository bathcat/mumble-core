using System.Diagnostics;
using Acme.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => this._logger = logger;

        public IActionResult Index() => this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            this.View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
                }
            );
    }
}
