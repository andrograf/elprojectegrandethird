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
                _logger.LogError(e, "{Repo} GetAllAsync method erorr", typeof(UserRepository));
                return new List<User>();
            }
        }

        public async Task<bool> Upsert(User entity)
        {
            try
            {
                var user = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (user == null)
                {
                    dbSet.Add(entity);
                    return true;
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
                _logger.LogError(e, "{Repo} GetByIdAsync method error", typeof(UserRepository));
                return false;
            }
        }
        //Task<bool> DeleteAsync(long id);
    }
}
