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
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
                
        }
        public override async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAllAsync method error", typeof(RecipeRepository));
                return new List<Recipe>();
            }
        }

        public override async Task<bool> UpdateAsync(Recipe recipe)
        {
            try
            {
                var existing = await dbSet.Where(x => x.Id == recipe.Id).FirstOrDefaultAsync();
                if (existing == null)
                {
                    return await AddAsync(recipe);
                }

                existing.Name = recipe.Name;
                
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} UpdateAsync method error", typeof(RecipeRepository));
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
                _logger.LogError(e, "{Repo} Delete method error", typeof(RecipeRepository));
                return false;
            }
        }
    }

}
