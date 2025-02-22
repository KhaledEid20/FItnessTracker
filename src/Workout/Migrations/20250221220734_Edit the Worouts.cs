﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout.Migrations
{
    /// <inheritdoc />
    public partial class EdittheWorouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "WorkOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WorkOuts");
        }
    }
}
