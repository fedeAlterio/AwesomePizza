namespace AwesomePizza.Application.Abstractions;
public interface IDbContext
{
    Task ApplyMigrations(CancellationToken cancellationToken); // TODO mettere da un altra parte
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
