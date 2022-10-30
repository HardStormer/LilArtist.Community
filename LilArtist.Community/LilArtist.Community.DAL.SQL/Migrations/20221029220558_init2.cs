using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LilArtist.Community.DAL.SQL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_UserId",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "roles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_roles_UserId",
                table: "roles",
                newName: "IX_roles_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_RoleId",
                table: "roles",
                column: "RoleId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_RoleId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "roles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_roles_RoleId",
                table: "roles",
                newName: "IX_roles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_UserId",
                table: "roles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
