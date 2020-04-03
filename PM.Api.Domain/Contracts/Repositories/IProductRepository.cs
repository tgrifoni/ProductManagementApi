using PM.Api.Domain.Models.Entities;

namespace PM.Api.Domain.Contracts.Repositories
{
    public interface IProductRepository : ICommandQueryRepository<Product>
    {
    }
}
