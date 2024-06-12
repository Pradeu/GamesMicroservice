using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnGameScoresCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "scoresCount",
                table: "games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scoresCount",
                table: "games");
        }
    }
}
