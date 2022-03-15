namespace BlazorAppCRUD.Client.Services.RecipeService {
    public interface IRecipeService {

        List<Recipe> Recipes { get; set; }
        Task GetAllRecipes();
        Task<Recipe> GetRecipeById(int id);
        Task CreateRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
    }
}
