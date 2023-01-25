using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace bitfit.DAL.Repositories
{
    public class FoodService : Service<Food>, IFoodService
    {
        public FoodService(AppDbContext context) : base(context)
        {
                
        }
        public override async Task<IEnumerable<Food>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} GetAllAsync method error", typeof(FoodService));
                return new List<Food>();
            }
        }

        public override async Task<bool> UpdateAsync(Food food)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == food.Id).FirstOrDefaultAsync();
                if (existing == null)
                {
                    await AddAsync(food);
                    
                }

                existing.Name = food.Name;
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} UpdateAsync method error", typeof(FoodService));
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existing != null)
                {
                    dbSet.Remove(existing);
                    await context.SaveChangesAsync();
                    return true;

                }

                return false;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} Delete method error", typeof(FoodService));
                return false;
            }
        }
    }

}
