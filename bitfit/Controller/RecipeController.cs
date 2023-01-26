using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _recipeService.AddAsync(recipe);

                return Ok(recipe);
            }

            return new JsonResult("You aint cooking this meal son.") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipeService.GetAllAsync();
            return Ok(recipes);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _recipeService.UpdateAsync(recipe);

            return NoContent();
        }

        [HttpDelete("/recipe/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return BadRequest();
            }

            await _recipeService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
