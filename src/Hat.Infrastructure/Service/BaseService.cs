using PipeSharp;

namespace Hat.Infrastructure.Service
{
    public class BaseService
    {
        public BaseService(IFlowBuilder<Error> flowBuilder)
        {
            PredefinedFlow = flowBuilder;
        }

        protected IFlowBuilder<Error> PredefinedFlow { get; }
    }
}