using bitfit.DAL.IServices;
using bitfit.DAL.Repositories;
using bitfit.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace bitfit.DAL.Servies
{
    public class GanttService : Service<Gantt>, IGanttService
    {
        public GanttService(AppDbContext context) : base(context)
        {

        }


        public override async Task<IEnumerable<Gantt>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }

            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetAllUsersAsync method error", typeof(UserService));
                return new List<Gantt>();
            }
        }

        public async Task<bool> UpdateAsync(Gantt gantt)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == gantt.Id).FirstOrDefaultAsync();
                if (existing == null)
                {
                    return false;
                }

                existing.StartDate = gantt.StartDate;
                existing.EndDate = gantt.EndDate;
                existing.Exercises = gantt.Exercises;
                dbSet.Update(existing);

                return true;
            }

            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetUserByIdAsync method error", typeof(UserService));
                return false;
            }
        }

        public async Task<bool> AddAsync(Gantt gantt)
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

    }
}
