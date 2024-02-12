using System.ComponentModel;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AwesomePizza.Web.Swagger;

public static class CustomSchemaStrategy
{
    public static void AddCustomSchemaOptions(this SwaggerGenOptions options)
    {
        options.CustomSchemaIds(GetSchemaIdByType);
    }

    static string GetSchemaIdByType(Type type)
    {
        var displayNameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        return displayNameAttribute?.DisplayName ?? type.Name
                                                        .Replace("Web", string.Empty)
                                                        .Replace("dto", string.Empty, StringComparison.InvariantCultureIgnoreCase);
    }
}
