using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Core;

public class AuthenticationRequest
{
    [Required]
    public string Login { get; set; } = String.Empty;

    [Required]
    public string Password { get; set; } = String.Empty;
}
