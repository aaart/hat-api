using System.Collections.Generic;
using System.Linq;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Hat.Services.Devices;
using Hat.Services.Devices.Dtos;
using Microsoft.Extensions.Logging;
using PipeSharp;

namespace Hat.Domain.Devices.Services
{
    public class GetDevicesService : BaseService<PagingRequest, IEnumerable<DeviceDescription>>, IGetDevicesService
    {
        public GetDevicesService(IFlowBuilder<Error> flowBuilder, ILoggerFactory loggerFactory) 
            : base(flowBuilder, loggerFactory)
        {
        }

        protected override IPipeline<IEnumerable<DeviceDescription>, Error> CreatePipeline(IFlow<PagingRequest, Error> flow, ILogger logger) =>
            flow
                .Finalize(x =>
                {
                    logger.LogInformation("I am printing information.");
                    return Enumerable.Empty<DeviceDescription>();
                });

    }
}