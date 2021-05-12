using Microsoft.EntityFrameworkCore.Migrations;

namespace Object_B.Migrations
{
    public partial class fixComp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_OwnerUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerUserId",
                table: "Companies",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_OwnerUserId",
                table: "Companies",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
