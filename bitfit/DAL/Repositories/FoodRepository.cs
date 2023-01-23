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
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(AppDbContext context, ILogger logger) : base(context, logger)
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
                _logger.LogError(e, "{Repo} GetAllAsync method error", typeof(FoodRepository));
                return new List<Food>();
            }
        }

        public override async Task<bool> UpdateAsync(Food food)
        {
            try
            {
                var existingIngredient = await dbSet.Where(x => x.Id == food.Id).FirstOrDefaultAsync();
                if (existingIngredient == null)
                {
                    return await AddAsync(food);
                }

                existingIngredient.Name = food.Name;
                
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} UpdateAsync method error", typeof(FoodRepository));
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var existingIngredient = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingIngredient != null)
                {
                    dbSet.Remove(existingIngredient);
                    return true;

                }

                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete method error", typeof(FoodRepository));
                return false;
            }
        }
    }

}
