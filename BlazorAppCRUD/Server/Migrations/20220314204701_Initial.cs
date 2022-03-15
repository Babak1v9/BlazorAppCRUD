using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppCRUD.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "CookingTime", "Description", "Difficulty", "Instructions", "Name", "PreparationTime", "Rating" },
                values: new object[] { 1, 624, 110, "Best ever spaghetti bolognese is super easy and a true Italian classic with a meaty, chilli sauce.", "Easy", "Test", "Spaghetti Bolognese", 25, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
