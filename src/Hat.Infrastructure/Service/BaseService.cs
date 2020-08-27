using System;
using PipeSharp;

namespace Hat.Infrastructure.Service
{
    public abstract class BaseService<TIn, TOut> : IService<TIn, TOut>
    {
        private readonly IFlowBuilder<Error> _builder;

        protected BaseService(IFlowBuilder<Error> flowBuilder)
        {
            _builder = flowBuilder;
        }

        protected abstract IPipeline<TOut, Error> CreatePipeline(IFlow<TIn, Error> flow);
        
        public IServiceResult<TOut> Execute(TIn input)
        {
            var pipeline = CreatePipeline(_builder.For(input));
            return ServiceResult<TOut>.SuccessResult(pipeline.Sink().Result.Value);
        }
    }
}