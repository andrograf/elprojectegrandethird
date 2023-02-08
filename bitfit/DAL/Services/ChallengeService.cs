using bitfit.DAL.IServices;
using bitfit.DAL.Repositories;
using bitfit.Model;
using bitfit.Model.Entities;
using bitfit.Utilities;
using Microsoft.EntityFrameworkCore;

namespace bitfit.DAL.Servies
{
    public class ChallengeService : Service<Challenge>, IChallengeService
    {
        public ChallengeService(AppDbContext context) : base(context)
        {

        }


        public override async Task<IEnumerable<Challenge>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }

            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetAllUsersAsync method error", typeof(UserService));
                return new List<Challenge>();
            }
        }

        public async Task<bool> UpdateAsync(Challenge gantt)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == gantt.Id).FirstOrDefaultAsync();
                if (existing == null)
                {
                    return false;
                }


                dbSet.Update(existing);

                return true;
            }

            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetUserByIdAsync method error", typeof(UserService));
                return false;
            }
        }

        public async Task<bool> AddAsync(Challenge gantt)
        {
            try
            {
                await dbSet.AddAsync(gantt);
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo}AddUserAsync method error", typeof(UserService));
                return false;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var gantt = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                dbSet.Remove(gantt);
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} DeleteUserAsync method error", typeof(UserService));
                return false;
            }
        }

        public Challenge GenerateChart(ChallengeSettings settings, User user)
        {
            Util util = new Util();
            var dailyCalories = util.CalculateDailyCalories(user);


            Challenge challenge = new Challenge();
            if(settings.ChallengeType == "WeightLoss")
            {
               
            }
            return challenge;
        }
    }
}
