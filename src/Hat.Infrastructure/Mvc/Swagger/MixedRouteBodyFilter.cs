using System;
using System.Linq;
using System.Reflection;
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
            var attrDefined = parameters.Count(x => x.GetCustomAttribute(typeof(FromHybridAttribute)) != null) == 1;
            if (attrDefined)
            {
                var parameter = parameters[0];
                if (parameter.ParameterType.BaseType != null && parameter.ParameterType.BaseType.IsGenericType)
                {
                    operation.Parameters.Clear();
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = parameter.ParameterType.BaseType.GetProperties().First().Name.ToLower(),
                        Required = true,
                        Schema = new OpenApiSchema { Type = "integer" },
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
        }
    }
}