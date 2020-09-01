using Hat.Infrastructure.Service;
using Hat.Services.Common.Dto;
using Hat.Services.Devices.Dto;

namespace Hat.Services.Devices.Services
{
    public interface IGetDeviceDetailsService : IService<ObjectRequest, DeviceDetails>
    {
        
    }
}