using bitfit.DAL.IServices;
using bitfit.DAL.Repositories;
using bitfit.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace bitfit.DAL.Servies
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context)
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
                //_logger.LogError(e, "{Repo} GetAllUsersAsync method error", typeof(UserService));
                return new List<User>();
            }
        }

        public override async Task<bool> UpdateAsync(User entity)
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
                context.SaveChangesAsync();

                return true;
            }

            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetUserByIdAsync method error", typeof(UserService));
                return false;
            }
        }

        public override async Task<bool> AddAsync(User entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo}AddUserAsync method error", typeof(UserService));
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var user = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                dbSet.Remove(user);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} DeleteUserAsync method error", typeof(UserService));
                return false;
            }
        }

        public async Task<User> GetByGuid(Guid id)
        {
            try
            {
                var user = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetUserByGuid method error", typeof(UserService));
                return null;
            }
        }
    }
}
