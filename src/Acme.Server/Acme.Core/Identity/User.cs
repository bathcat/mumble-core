using Microsoft.AspNetCore.Identity;
using System;

namespace Acme.Core.Identity;

public class User : IdentityUser<Guid>
{
    public string GivenName { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
}
