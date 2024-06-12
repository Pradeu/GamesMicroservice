using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Game.DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateEngineDeveloperTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "developer",
                table: "games");

            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_developers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "engines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_engines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "developerGames",
                columns: table => new
                {
                    gameId = table.Column<int>(type: "integer", nullable: false),
                    developerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_developerGames", x => new { x.developerId, x.gameId });
                    table.ForeignKey(
                        name: "fK_developerGames_developers_developerId",
                        column: x => x.developerId,
                        principalTable: "developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fK_developerGames_games_gameId",
                        column: x => x.gameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "engineGames",
                columns: table => new
                {
                    gameId = table.Column<int>(type: "integer", nullable: false),
                    engineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_engineGames", x => new { x.engineId, x.gameId });
                    table.ForeignKey(
                        name: "fK_engineGames_engines_engineId",
                        column: x => x.engineId,
                        principalTable: "engines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fK_engineGames_games_gameId",
                        column: x => x.gameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_developerGames_gameId",
                table: "developerGames",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "iX_engineGames_gameId",
                table: "engineGames",
                column: "gameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "developerGames");

            migrationBuilder.DropTable(
                name: "engineGames");

            migrationBuilder.DropTable(
                name: "developers");

            migrationBuilder.DropTable(
                name: "engines");

            migrationBuilder.AddColumn<string>(
                name: "developer",
                table: "games",
                type: "text",
                nullable: true);
        }
    }
}
