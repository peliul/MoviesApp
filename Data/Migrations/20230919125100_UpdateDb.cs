using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesListApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Preferences_PreferencesId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PreferencesId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PreferencesId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "FavoriteCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    PreferencesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCategories", x => new { x.CategoryId, x.PreferencesId });
                    table.ForeignKey(
                        name: "FK_FavoriteCategories_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCategories_Preferences_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteMovies",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMovies", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_FavoriteMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCategories_CategoryId1",
                table: "FavoriteCategories",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMovies_MovieId",
                table: "FavoriteMovies",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCategories");

            migrationBuilder.DropTable(
                name: "FavoriteMovies");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreferencesId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PreferencesId",
                table: "Categories",
                column: "PreferencesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Preferences_PreferencesId",
                table: "Categories",
                column: "PreferencesId",
                principalTable: "Preferences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
