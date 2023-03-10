using Acme.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Acme.Web;

[ApiController]
[Route("[controller]")]
public class AuthenticationRequestsController : ControllerBase
{
    private readonly ISecurityService securityService;

    public AuthenticationRequestsController(ISecurityService service)
    {
        this.securityService = service;
    }

    [HttpPost()]
    public Task<AuthenticatedUser?> Authenticate(AuthenticationRequest model)
    {
        return this.securityService.Authenticate(model);
    }
}
