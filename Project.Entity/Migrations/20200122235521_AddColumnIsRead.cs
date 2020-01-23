using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Entity.Migrations
{
    public partial class AddColumnIsRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ToDoDatas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ToDoDatas");
        }
    }
}
