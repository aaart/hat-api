using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Service
{
    public class Dto
    {
    }

    public class Dto<TId> : Dto
    {
        [FromRoute]
        public TId Id { get; set; } = default!;
    }
}