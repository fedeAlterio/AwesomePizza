using FluentValidation;

namespace AwesomePizza.Web.DependenciesInstallers;

public static class FluentValidationInstaller
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(IAssemblyMarker));
    }
}
