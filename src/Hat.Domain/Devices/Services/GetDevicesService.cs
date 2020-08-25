using System.Collections.Generic;
using System.Linq;
using Hat.Infrastructure.Service;
using Hat.Services.Devices;
using Hat.Services.Devices.Dtos;

namespace Hat.Domain.Devices.Services
{
    public class GetDevicesService : IGetDevicesService
    {
        public IServiceResult<IEnumerable<DeviceDescription>> Execute() => new ServiceResult<IEnumerable<DeviceDescription>>(Enumerable.Empty<DeviceDescription>());
    }
}