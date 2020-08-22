using System.Collections.Generic;
using Hat.Infrastructure.Service;
using Hat.Services.Devices.Dtos;

namespace Hat.Services.Devices
{
    public interface IGetDevicesService
    {
        IServiceResult<IEnumerable<DeviceDescription>> Execute();
    }
}