namespace AwesomePizza.Models.Common;
public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? @this) => @this is null || !@this.Any();
}
