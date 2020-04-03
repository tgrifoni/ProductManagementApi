using System.Threading.Tasks;

namespace PM.Api.Domain.Contracts.Repositories
{
    public interface ICommandRepository<T>
    {
        Task<long> AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(long id);
    }
}
