using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PipeSharp;

namespace Hat.Infrastructure.Service
{
    public abstract class BaseService<TIn, TOut> : IService<TIn, TOut>
    {
        private readonly IFlowBuilder<Error> _builder;
        private readonly ILogger _logger;

        protected BaseService(IFlowBuilder<Error> flowBuilder, ILoggerFactory loggerFactory)
        {
            _builder = flowBuilder;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        protected abstract IPipeline<TOut, Error> CreatePipeline(IFlow<TIn, Error> flow, ILogger logger);
        
        public IServiceResult<TOut> Execute(TIn input)
        {
            var pipeline = CreatePipeline(_builder.For(input), _logger);
            var (result, errors) = pipeline.Sink();
            if (result.Failed)
            {
                return ServiceResult<TOut>.FailedResult(errors);
            }
            return ServiceResult<TOut>.SuccessResult(result.Value);
        }
    }
}