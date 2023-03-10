using System;
using System.Threading.Tasks;

namespace Acme.Core;

public class AuthenticatedUser
{
    public Guid ID { get; set; } = Guid.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}

public interface ISecurityService
{
    Task<AuthenticatedUser?> Authenticate(AuthenticationRequest request);
}
