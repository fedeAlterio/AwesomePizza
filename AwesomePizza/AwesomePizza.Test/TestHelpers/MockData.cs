using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Orders;

namespace AwesomePizza.Test.TestHelpers;
public static class MockData
{
    public static List<Guid> GetGuids() => new[]
    {
        "a42cebf8-32e5-4041-b6a1-d390a4a77d7a",
        "765beeb8-a245-4822-9f93-b20646e5aa16",
        "89b6a3f9-00a1-4b23-b8bd-2f1750249248"
    }.Select(x => Guid.Parse(x)).ToList();

    public static OrderId OrderId() => new(GetGuids().First());
    public static DishId DishId() => new(GetGuids().Skip(1).First());

    public static Dish CreateDish(Guid guid) => new (new(guid), new(guid.ToString()), new(guid.ToString()), new(16));
}
