using AuthService.Domain.Entities;
using Domain.Aggregates.Accounts;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<AccountToken> AccountTokens => Set<AccountToken>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
