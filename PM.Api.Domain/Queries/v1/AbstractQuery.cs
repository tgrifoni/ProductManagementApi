using MediatR;

namespace PM.Api.Domain.Queries.v1
{
    public abstract class AbstractQuery<T> : IRequest<T>
    {
    }
}
