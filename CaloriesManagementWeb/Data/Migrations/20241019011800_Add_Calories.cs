﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaloriesManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Calories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "User");
        }
    }
}