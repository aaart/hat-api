namespace Hat.Infrastructure.Service
{
    public interface IResourceCreatedServiceResult<out TId> : IServiceResult
    {
        TId Id { get; }
    }
}