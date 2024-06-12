using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationUserListtoUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fK_userLists_gameStatuses_userStatusId",
                table: "userLists");

            migrationBuilder.DropIndex(
                name: "iX_userLists_userStatusId",
                table: "userLists");

            migrationBuilder.DropColumn(
                name: "userStatusId",
                table: "userLists");

            migrationBuilder.AlterColumn<int>(
                name: "statusId",
                table: "userLists",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "iX_userLists_statusId",
                table: "userLists",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "fK_userLists_gameStatuses_userStatusId",
                table: "userLists",
                column: "statusId",
                principalTable: "gameStatuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fK_userLists_gameStatuses_userStatusId",
                table: "userLists");

            migrationBuilder.DropIndex(
                name: "iX_userLists_statusId",
                table: "userLists");

            migrationBuilder.AlterColumn<int>(
                name: "statusId",
                table: "userLists",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "userStatusId",
                table: "userLists",
                type: "integer",
                nullable: true);

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
    }
}
