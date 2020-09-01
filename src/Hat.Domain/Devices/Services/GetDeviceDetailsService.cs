using Hat.Infrastructure.Service;
using Hat.Services.Common.Dto;
using Hat.Services.Devices.Dto;
using Hat.Services.Devices.Services;
using Microsoft.Extensions.Logging;
using PipeSharp;

namespace Hat.Domain.Devices.Services
{
    public class GetDeviceDetailsService : BaseService<ObjectRequest, DeviceDetails>, IGetDeviceDetailsService
    {
        public GetDeviceDetailsService(IFlowBuilder<Error> flowBuilder, ILoggerFactory loggerFactory) 
            : base(flowBuilder, loggerFactory)
        {
        }

        protected override IPipeline<DeviceDetails, Error> CreatePipeline(IFlow<ObjectRequest, Error> flow, ILogger logger) =>
            flow.Finalize(request => new DeviceDetails());
    }
}