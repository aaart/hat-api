using System;
using System.Linq;
using System.Reflection;
using Hat.Infrastructure.Service;
using HybridModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hat.Infrastructure.Mvc.Swagger
{
    public class MixedRouteBodyFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = context.MethodInfo.GetParameters();
            var parameter = parameters.FirstOrDefault(x => x.GetCustomAttribute(typeof(FromHybridAttribute)) != null);
            if (parameter != null && IsDerivedFromBaseGenericDto(parameter.ParameterType))
            {
                var idProperty = parameter.ParameterType.GetProperties().First(p => p.Name == "Id");
                operation.Parameters.Clear();
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = idProperty.Name.ToLower(),
                    Required = true,
                    Schema = new OpenApiSchema { Type = idProperty.PropertyType == typeof(int) ? "integer" : idProperty.PropertyType.Name },
                    In = ParameterLocation.Path
                });

                operation.RequestBody = new OpenApiRequestBody();
                var parameterSchema = context.SchemaRepository.Schemas[parameter.ParameterType.Name];
                var paramaterSchemaNoId = new OpenApiSchema
                {
                    Properties = parameterSchema.Properties
                        .Where(x => !string.Equals("id", x.Key, StringComparison.InvariantCultureIgnoreCase))
                        .ToDictionary(x => x.Key, x => x.Value)
                };
                operation.RequestBody.Content.Add("application/json", new OpenApiMediaType
                {
                    Schema = paramaterSchemaNoId
                });
            }
        }
        
        public static bool IsDerivedFromBaseGenericDto(Type type)
        {
            while (type.BaseType != null)
            {
                if (type.BaseType.IsConstructedGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(Dto<>))
                {
                    return true;
                }

                type = type.BaseType;
            }
            return false;
        } 
    }
}