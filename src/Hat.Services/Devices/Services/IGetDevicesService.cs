using System.Collections.Generic;
using Hat.Infrastructure.Service;
using Hat.Services.Common.Dto;
using Hat.Services.Devices.Dto;

namespace Hat.Services.Devices.Services
{
    public interface IGetDevicesService : IService<PagingRequest, IEnumerable<DeviceDescription>>
    {
    }
}