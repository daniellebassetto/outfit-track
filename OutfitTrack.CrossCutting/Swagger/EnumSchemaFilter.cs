using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.Serialization;

namespace OutfitTrack.CrossCutting.Swagger;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            var enumType = context.Type;
            var enumValues = Enum.GetValues(enumType).Cast<Enum>();

            schema.Enum.Clear();

            foreach (var enumValue in enumValues)
            {
                var field = enumType.GetField(enumValue.ToString());

                var attribute = field?.GetCustomAttribute<EnumMemberAttribute>();

                var description = attribute?.Value ?? enumValue.ToString();
                var enumItem = new OpenApiString($"{description} - {Convert.ToInt32(enumValue)}");

                schema.Enum.Add(enumItem);
            }
        }
    }
}