using System.Collections.Generic;
using System.Linq;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Hat.Services.Devices;
using Hat.Services.Devices.Dtos;
using PipeSharp;

namespace Hat.Domain.Devices.Services
{
    public class GetDevicesService : BaseService<PagingRequest, IEnumerable<DeviceDescription>>, IGetDevicesService
    {
        public GetDevicesService(IFlowBuilder<Error> flowBuilder) : base(flowBuilder)
        {
        }

        protected override IPipeline<IEnumerable<DeviceDescription>, Error> CreatePipeline(IFlow<PagingRequest, Error> flow) =>
            flow
                .Finalize(x => Enumerable.Empty<DeviceDescription>());

    }
}