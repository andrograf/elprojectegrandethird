using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace bitfit.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
            
        }


        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }

            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAllUsersAsync method error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        { 
            try
            {
                var user = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return false;
                }

                user.Name = entity.Name;
                user.Email = entity.Email;
                user.WeightInKg = entity.WeightInKg;
                user.HeightInCm = entity.HeightInCm;
                user.BMI = user.CalculateBMI();

                return true;
            }

            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetUserByIdAsync method error", typeof(UserRepository));
                return false;
            }
        }

        public async Task<bool> AddAsync(User entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch(Exception e) {
                _logger.LogError(e, "{Repo}AddUserAsync method error", typeof(UserRepository));
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var user = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                dbSet.Remove(user);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} DeleteUserAsync method error", typeof(UserRepository));
                return false;
            }
        }

        public Task<User> GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
