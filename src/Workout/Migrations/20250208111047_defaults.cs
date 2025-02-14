using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout.Migrations
{
    /// <inheritdoc />
    public partial class defaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_userId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_userId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_userId",
                table: "Exercises",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_userId",
                table: "Exercises",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
