using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaloriesManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class nodaywarning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoDayWarning",
                table: "Day_User",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoDayWarning",
                table: "Day_User");
        }
    }
}
