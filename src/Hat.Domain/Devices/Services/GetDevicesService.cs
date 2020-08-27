using System.Collections.Generic;
using System.Linq;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Hat.Services.Devices;
using Hat.Services.Devices.Dtos;
using PipeSharp;

namespace Hat.Domain.Devices.Services
{
    public class GetDevicesService : BaseService, IGetDevicesService
    {
        public GetDevicesService(IFlowBuilder<Error> flowBuilder) : base(flowBuilder)
        {
        }

        public IServiceResult<IEnumerable<DeviceDescription>> Execute(PagingRequest input) =>
            PredefinedFlow
                .For(input)
                .Finalize(x => Enumerable.Empty<DeviceDescription>())
                .Project(x => new ServiceResult<IEnumerable<DeviceDescription>>(x))
                .Sink().Result.Value;

    }
}