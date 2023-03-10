using Acme.Core;
using Microsoft.Extensions.Configuration;

namespace Acme.Api.Extensions;

public static class ConfigurationManagerExtensions
{
    public static JwtSettings GetJwtSettings(this ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        return jwtSettings;
    }
}
