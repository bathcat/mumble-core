using System;

namespace Acme.Core;

public class JwtSettings
{
    public string AccessTokenSecret { get; set; } = String.Empty;
    public string RefreshTokenSecret { get; set; } = String.Empty;
    public double AccessTokenExpirationMinutes { get; set; }
    public double RefreshTokenExpirationMinutes { get; set; }
    public string Issuer { get; set; } = String.Empty;
    public string Audience { get; set; } = String.Empty;
}
