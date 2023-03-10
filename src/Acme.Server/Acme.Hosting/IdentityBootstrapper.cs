using Acme.Core.Identity;
using Acme.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Hosting;

public class IdentityBootstrapper
{
    private readonly RoleManager<Role> roleManager;
    private readonly UserManager<User> userManager;
    private readonly IdentityDbContext dbContext;

    public IdentityBootstrapper(
        RoleManager<Role> roleManager,
        UserManager<User> userManager,
        IdentityDbContext dbContext
    )
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
        this.dbContext = dbContext;
    }

    public async Task Seed()
    {
        await this.dbContext.EnsureSchema();
        await this.Roles();
        await this.Users();
    }

    private async Task Roles()
    {
        if (this.roleManager.Roles.Any())
        {
            return;
        }
        var result = await this.roleManager.CreateAsync(new Role { Name = "Administrators" });
        if (result.Errors.Any())
        {
            throw new Exception("Unable to build role.");
        }
    }

    private async Task Users()
    {
        if (this.userManager.Users.Any())
        {
            return;
        }

        const string password = "Password1!";

        var user = new User()
        {
            UserName = "jbloggs@example.com",
            GivenName = "Joe",
            Surname = "Bloggs",
            Email = "jbloggs@example.com",
            EmailConfirmed = true,
            PhoneNumber = "555-1212",
            PhoneNumberConfirmed = true,
        };

        await this.userManager.CreateAsync(user, password);
        await this.userManager.AddToRoleAsync(user, "Administrators");
        await this.userManager.AddClaimAsync(
            user,
            new System.Security.Claims.Claim(
                System.Security.Claims.ClaimTypes.DateOfBirth,
                "2000-06-06",
                System.Security.Claims.ClaimValueTypes.Date
            )
        );
    }
}
