namespace Hat.Infrastructure.Service
{
    public interface IService<in TIn, out TOut>
    {
        IServiceResult<TOut> Execute(TIn input);
    }
}