using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmallImageName",
                table: "Sliders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallImageName",
                table: "Sliders");
        }
    }
}
