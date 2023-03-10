using Acme.Core;
using Acme.Core.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Acme.Identity;

public class TokenService : ITokenService
{
    private readonly JwtSettings settings;

    public TokenService(JwtSettings settings)
    {
        this.settings = settings;
    }

    public string BuildToken(User user)
    {
        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(this.settings.AccessTokenSecret)
        );

        // // Create standard JWT claims
        var jwtClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //foreach (var customClaim in user.Claims)
        //{
        //   jwtClaims.Add(new Claim(customClaim.ClaimType, customClaim.ClaimValue));
        //}

        // Create the JwtSecurityToken object
        var token = new JwtSecurityToken(
            issuer: this.settings.Issuer,
            audience: this.settings.Audience,
            notBefore: DateTime.UtcNow,
            claims: jwtClaims,
            expires: DateTime.UtcNow.AddMinutes(this.settings.AccessTokenExpirationMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        // Create string representation of Jwt token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var mySecret = System.Text.Encoding.UTF8.GetBytes(this.settings.AccessTokenSecret);
        var mySecurityKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = this.settings.Issuer,
                    ValidAudience = this.settings.Audience,
                    IssuerSigningKey = mySecurityKey,
                },
                out SecurityToken validatedToken
            );
        }
        catch
        {
            return false;
        }
        return true;
    }
}
