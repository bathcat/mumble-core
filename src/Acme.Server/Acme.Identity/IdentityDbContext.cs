using Acme.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acme.Identity;

public class IdentityDbContext
    : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity_AspNet");

        builder.Entity<User>(b =>
        {
            b.ToTable(nameof(User));
        });

        builder.Entity<Role>(b =>
        {
            b.ToTable(nameof(Role));
        });

        builder.Entity<UserClaim>(b =>
        {
            b.ToTable(nameof(UserClaim));
        });

        builder.Entity<UserRole>(b =>
        {
            b.ToTable(nameof(UserRole));
        });

        builder.Entity<UserLogin>(b =>
        {
            b.ToTable(nameof(UserLogin));
        });

        builder.Entity<RoleClaim>(b =>
        {
            b.ToTable(nameof(RoleClaim));
        });

        builder.Entity<UserToken>(b =>
        {
            b.ToTable(nameof(UserToken));
        });
    }
}
