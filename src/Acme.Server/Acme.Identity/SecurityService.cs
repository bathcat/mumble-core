using Acme.Core;
using Acme.Core.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Identity;

public class SecurityService : ISecurityService
{
    private readonly ITokenService tokenService;

    private readonly SignInManager<User> signInManager;
    private readonly IdentityDbContext context;

    public SecurityService(
        ITokenService tokenService,
        SignInManager<User> signInManager,
        IdentityDbContext context
    )
    {
        this.tokenService = tokenService;
        this.signInManager = signInManager;
        this.context = context;
    }

    public async Task<AuthenticatedUser?> Authenticate(AuthenticationRequest model)
    {
        var result = await this.signInManager.PasswordSignInAsync(
            model.Login,
            model.Password,
            false,
            false
        );
        if (!result.Succeeded)
        {
            return null;
        }

        var user = this.context.Users.Single(u => u.Email == model.Login);

        return new AuthenticatedUser
        {
            GivenName = user.GivenName,
            Surname = user.Surname,
            Login = user.Email,
            ID = user.Id,
            Token = this.tokenService.BuildToken(user),
        };
    }
}
