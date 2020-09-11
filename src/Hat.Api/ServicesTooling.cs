using System.Linq;
using System.Reflection;
using Hat.Domain.Devices.Services;
using Hat.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hat.Api
{
    public static class ServicesTooling
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            var assembly = typeof(GetDevicesService).Assembly;
            var domainServices = 
                assembly
                    .GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseService<,>));

            foreach (var domainService in domainServices)
            {
                var contract = domainService.GetInterfaces().Single(i => !i.IsGenericType);
                services.AddScoped(contract, domainService);
            }
        }
    }
}