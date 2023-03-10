using Acme.Core.Identity;

namespace Acme.Core;

public interface ITokenService
{
    string BuildToken(User user);
    bool ValidateToken(string token);
}
