using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingEmailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branchs_BranchBranchId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Branchs_BranchBrandId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Branchs_BranchBrandId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BranchBrandId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BranchBrandId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "BranchBrandId",
                table: "Students",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_BranchBrandId",
                table: "Students",
                newName: "IX_Students_BranchId");

            migrationBuilder.RenameColumn(
                name: "BranchBrandId",
                table: "Instructors",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_BranchBrandId",
                table: "Instructors",
                newName: "IX_Instructors_BranchId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Departments",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Branchs",
                newName: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branchs_BranchId",
                table: "Departments",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Branchs_BranchId",
                table: "Instructors",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Branchs_BranchId",
                table: "Students",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branchs_BranchId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Branchs_BranchId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Branchs_BranchId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BranchId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Students",
                newName: "BranchBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_BranchId",
                table: "Students",
                newName: "IX_Students_BranchBrandId");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Instructors",
                newName: "BranchBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_BranchId",
                table: "Instructors",
                newName: "IX_Instructors_BranchBrandId");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Departments",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Branchs",
                newName: "BrandId");

            migrationBuilder.AddColumn<int>(
                name: "BranchBrandId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchBrandId",
                table: "Departments",
                column: "BranchBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branchs_BranchBrandId",
                table: "Departments",
                column: "BranchBrandId",
                principalTable: "Branchs",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Branchs_BranchBrandId",
                table: "Instructors",
                column: "BranchBrandId",
                principalTable: "Branchs",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Branchs_BranchBrandId",
                table: "Students",
                column: "BranchBrandId",
                principalTable: "Branchs",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
