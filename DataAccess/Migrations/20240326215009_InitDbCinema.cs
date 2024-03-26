using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDbCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Dune is a 2021 American epic science fiction film directed by Denis Villeneuve, who co-wrote the screenplay with Jon Spaihts and Eric Roth", new TimeSpan(0, 2, 35, 0, 0), "Fantasy", "Dune", 2021 },
                    { 2, "John, an ex-CIA officer, is entrusted with the responsibility of safeguarding an entrepreneur's daughter. When the girl gets kidnapped, John vows to seek revenge.", new TimeSpan(0, 2, 26, 0, 0), "Drama/Action/Triller", "Main on Fire", 2004 },
                    { 3, "Commodus takes over power and demotes Maximus, one of the preferred generals of his father, Emperor Marcus Aurelius. As a result, Maximus is relegated to fighting till death as a gladiator.", new TimeSpan(0, 2, 35, 0, 0), "History/Action/Drama", "Gladiator", 2000 },
                    { 4, "When a group of firefighters from California ignores a warning by Superintendent Eric Marsh about a wildfire, he decides to get his crew certified as wildfire hotshots.", new TimeSpan(0, 2, 13, 0, 0), "Drama/Triller", "Only the Brave", 2017 },
                    { 5, "Baker Dill is a fishing boat captain who leads tours off of the tranquil enclave of Plymouth Island. His peaceful life is soon shattered when his ex-wife Karen tracks him down. Desperate for help, Karen begs Baker to save her -- and their young son -- from her abusive husband. She wants him to take the brute out for a fishing excursion -- then throw him overboard to the sharks. Thrust back into a life that he wanted to forget, Baker now finds himself struggling to choose between right and wrong.", new TimeSpan(0, 1, 46, 0, 0), "Drama/Triller", "Serenity", 2019 },
                    { 6, "An unmanned, half-mile-long freight train hurtles towards a town at breakneck speed. An engineer and a young conductor, who happen to be on the same route, must race against time to try and stop it.", new TimeSpan(0, 1, 38, 0, 0), "Action/Drama", "Unstoppable", 2010 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
