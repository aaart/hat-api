namespace Hat.Infrastructure.Service
{
    public class ResourceCreatedServiceResult<TId> : ServiceResult, IResourceCreatedServiceResult<TId>
    {
        public ResourceCreatedServiceResult(TId id)
            : base()
        {
            Id = id;
        }

        public ResourceCreatedServiceResult(Status status)
            : base(status)
        {
            Id = default(TId)!;
        }
        
        public TId Id { get; }
    }
}