using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaloriesManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class whaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DailyCalories",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyCalories",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
