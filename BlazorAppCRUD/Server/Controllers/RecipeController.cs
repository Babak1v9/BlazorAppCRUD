using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppCRUD.Server.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase {

        private readonly DataContext _context;

        public RecipeController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetAllRecipes() {

            var recipes = await _context.Recipes.ToListAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeByID(int id) {

            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null) {
                return NotFound($"Sorry, no recipe found for ID {id}");
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<List<Recipe>>> CreateRecipe(Recipe recipe) {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Recipe>>> UpdateRecipe(Recipe recipe, int id) {
            var dbRecipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (dbRecipe == null)
                return NotFound("Sorry, no recipe found.");

            dbRecipe.Name = recipe.Name;
            dbRecipe.Description = recipe.Description;
            dbRecipe.Rating = recipe.Rating;
            dbRecipe.PreparationTime = recipe.PreparationTime;
            dbRecipe.CookingTime = recipe.CookingTime;
            dbRecipe.Difficulty = recipe.Difficulty;
            dbRecipe.Calories = recipe.Calories;
            dbRecipe.Instructions = recipe.Instructions;

            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Recipe>>> DeleteRecipe (int id) {
            var dbRecipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (dbRecipe == null)
                return NotFound("Sorry, no recipe found.");

            _context.Recipes.Remove(dbRecipe);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }

        private async Task<List<Recipe>> GetDbRecipes() {

            return await _context.Recipes.ToListAsync(); 
        }

    }
}
