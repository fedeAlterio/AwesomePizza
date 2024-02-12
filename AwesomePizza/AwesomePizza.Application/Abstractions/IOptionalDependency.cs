namespace AwesomePizza.Application.Abstractions;
public interface IOptionalDependency<out T>
{
    public T? Value { get; }
}
