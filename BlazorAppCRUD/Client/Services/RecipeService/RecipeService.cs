using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppCRUD.Client.Services.RecipeService {
    public class RecipeService : IRecipeService {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public RecipeService(HttpClient http, NavigationManager navigationManager) {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public async Task CreateRecipe(Recipe recipe) {
            var result = await _http.PostAsJsonAsync("api/recipe", recipe);
            await SetRecipes(result);
        }

        public async Task DeleteRecipe(int id) {
            var result = await _http.DeleteAsync($"api/recipe/{id}");
            await SetRecipes(result);
        }

        public async Task GetAllRecipes() {
            var result = await _http.GetFromJsonAsync<List<Recipe>>("api/recipe");
            if (result != null)
                Recipes = result;
        }

        public async Task<Recipe> GetRecipeById(int id) {
            var result = await _http.GetFromJsonAsync<Recipe>($"api/recipe/{id}");
            if (result != null)
                return result;
            throw new Exception("Recipe not found!");
        }

        public async Task UpdateRecipe(Recipe recipe) {
            var result = await _http.PutAsJsonAsync($"api/recipe/{recipe.Id}", recipe);
            await SetRecipes(result);
        }

        private async Task SetRecipes(HttpResponseMessage result) {

            var response = await result.Content.ReadFromJsonAsync<List<Recipe>>();
            Recipes = response;
            _navigationManager.NavigateTo("recipes");
        }
    }
}
