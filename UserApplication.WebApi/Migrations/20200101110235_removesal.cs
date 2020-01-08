using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApplication.WebApi.Migrations
{
    public partial class removesal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Albums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Albums",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
