namespace BlazorAppCRUD.Server.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe {
                    Id = 1,
                    Name = "Spaghetti Bolognese",
                    Description = "Best ever spaghetti bolognese is super easy and a true Italian classic with a meaty, chilli sauce.",
                    Rating = 4,
                    PreparationTime = 25,
                    CookingTime = 110,
                    Difficulty = "Easy",
                    Calories = 624,
                    Instructions = "Test",
                }
                );
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
