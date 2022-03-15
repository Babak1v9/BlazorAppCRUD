using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppCRUD.Shared {
    public class Recipe {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Rating { get; set; } = 0;

        public int PreparationTime { get; set; } = 0;

        public int CookingTime { get; set; } = 0;

        public string Difficulty { get; set; } = string.Empty;

        public int Calories { get; set; } = 0;

        //public List<Ingredient> Ingredients { get; } = new List<Ingredient>();

        public string Instructions { get; set; } = string.Empty;

        public Recipe() {

        }

        //public void AddIngredient(string name, int quantity, string unit) {
         //   if (!Ingredients.Any(x => x.Name == name)) {
         //      Ingredients.Add(new Ingredient(name, quantity, unit));
         //   }
        //}
    }
}
