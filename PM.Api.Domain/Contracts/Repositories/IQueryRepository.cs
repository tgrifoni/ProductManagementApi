using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Api.Domain.Contracts.Repositories
{
    public interface IQueryRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
