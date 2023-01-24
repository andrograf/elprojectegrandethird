using System.Collections.Generic;
using System.Threading.Tasks;

namespace bitfit.DAL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        abstract Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<bool> UpdateAsync(T entity);
    }
}
