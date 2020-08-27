using System.Collections.Generic;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Hat.Services.Devices.Dtos;

namespace Hat.Services.Devices
{
    public interface IGetDevicesService : IService<PagingRequest, IEnumerable<DeviceDescription>>
    {
    }
}