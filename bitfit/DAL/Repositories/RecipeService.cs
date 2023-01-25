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
    public class RecipeService : Service<Recipe>, IRecipeService
    {
        public RecipeService(AppDbContext context) : base(context)
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
                //_logger.LogError(e, "{Repo} GetAllAsync method error", typeof(RecipeService));
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
                    await AddAsync(recipe);
                }

                existing.Name = recipe.Name;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} UpdateAsync method error", typeof(RecipeService));
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
                    await context.SaveChangesAsync();
                    return true;

                }

                return false;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "{Repo} Delete method error", typeof(RecipeService));
                return false;
            }
        }
    }

}
