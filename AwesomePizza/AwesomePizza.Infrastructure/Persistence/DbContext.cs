using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AwesomePizza.Models.Orders;
using AwesomePizza.Application.Abstractions;
using AwesomePizza.Models.Dishes;

namespace AwesomePizza.Infrastructure.Persistence;
internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IDbContext
{
    public required DbSet<Dish> Dishes { get; init; }
    public required DbSet<Order> Orders { get; init; }
    public required DbSet<OrderEvent> OrderEvents { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task ApplyMigrations(CancellationToken cancellationToken)
    {
        //await Database.EnsureCreatedAsync(cancellationToken);
        await Database.MigrateAsync(cancellationToken: cancellationToken);
    }
}
