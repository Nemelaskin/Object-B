using Microsoft.EntityFrameworkCore.Migrations;

namespace Object_B.Migrations
{
    public partial class AddFlagToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsACoridor",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsACoridor",
                table: "Rooms");
        }
    }
}
