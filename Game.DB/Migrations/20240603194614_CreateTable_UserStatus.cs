using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Game.DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "userLists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userStatusId",
                table: "userLists",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "gameStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_gameStatuses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "iX_userLists_userStatusId",
                table: "userLists",
                column: "userStatusId");

            migrationBuilder.AddForeignKey(
                name: "fK_userLists_gameStatuses_userStatusId",
                table: "userLists",
                column: "userStatusId",
                principalTable: "gameStatuses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fK_userLists_gameStatuses_userStatusId",
                table: "userLists");

            migrationBuilder.DropTable(
                name: "gameStatuses");

            migrationBuilder.DropIndex(
                name: "iX_userLists_userStatusId",
                table: "userLists");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "userLists");

            migrationBuilder.DropColumn(
                name: "userStatusId",
                table: "userLists");
        }
    }
}
