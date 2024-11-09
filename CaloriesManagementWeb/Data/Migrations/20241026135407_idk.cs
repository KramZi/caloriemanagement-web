using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaloriesManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GainedCalories",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Day");

            migrationBuilder.CreateTable(
                name: "Day_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GainedCalories = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day_User");

            migrationBuilder.AddColumn<int>(
                name: "GainedCalories",
                table: "Day",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Day",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
