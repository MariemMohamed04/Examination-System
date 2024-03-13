using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BrandID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          /*  migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Instructors");
*/
          /*  migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Instructors");*/
/*
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Departments");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
      /*      migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);*/

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
