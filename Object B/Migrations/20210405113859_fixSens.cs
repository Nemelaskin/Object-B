using Microsoft.EntityFrameworkCore.Migrations;

namespace Object_B.Migrations
{
    public partial class fixSens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Users_UserId",
                table: "Sensors");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sensors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Users_UserId",
                table: "Sensors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Users_UserId",
                table: "Sensors");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sensors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Users_UserId",
                table: "Sensors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
