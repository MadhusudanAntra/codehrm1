using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.API.Data;

public class AuthenticationDbContext: IdentityDbContext<User,IdentityRole<Guid>, Guid>
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(ConfigureUser);
        modelBuilder.Entity<IdentityUserClaim<Guid>>(uc => uc.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<Guid>>(uc => uc.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityUserToken<Guid>>(uc => uc.ToTable("UserTokens"));
        modelBuilder.Entity<IdentityRole<Guid>>(uc => uc.ToTable("Roles"));
        modelBuilder.Entity<IdentityUserRole<Guid>>(uc => uc.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(uc => uc.ToTable("UserRoleClaims"));

    }
    
  
    private void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).HasMaxLength(128);
        builder.Property(u => u.LastName).HasMaxLength(128);
    }
}