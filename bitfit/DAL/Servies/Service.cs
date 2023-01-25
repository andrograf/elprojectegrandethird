using System.Collections.Generic;
using System.Threading.Tasks;
using bitfit.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace bitfit.DAL.Repositories
{
    public class Service<T> : IService<T> where T : class
    {
        protected AppDbContext context;

        protected DbSet<T> dbSet;

        public Service(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
