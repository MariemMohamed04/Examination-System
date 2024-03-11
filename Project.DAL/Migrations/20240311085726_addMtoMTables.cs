using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addMtoMTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesCourseId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDepartmentId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourseId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Courses_CoursesCourseId",
                table: "CourseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Questions_QuestionsQuestionId",
                table: "CourseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QType",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionsQuestionId",
                table: "CourseQuestion",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseQuestion",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseQuestion_QuestionsQuestionId",
                table: "CourseQuestion",
                newName: "IX_CourseQuestion_QuestionId");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseInstructor",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDepartmentId",
                table: "CourseDepartment",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseDepartment",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentsDepartmentId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "QDegree",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CourseId",
                table: "CourseDepartment",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentId",
                table: "CourseDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CourseId",
                table: "CourseInstructor",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestion_Courses_CourseId",
                table: "CourseQuestion",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestion_Questions_QuestionId",
                table: "CourseQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CourseId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CourseId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Courses_CourseId",
                table: "CourseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Questions_QuestionId",
                table: "CourseQuestion");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "CourseQuestion",
                newName: "QuestionsQuestionId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseQuestion",
                newName: "CoursesCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseQuestion_QuestionId",
                table: "CourseQuestion",
                newName: "IX_CourseQuestion_QuestionsQuestionId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseInstructor",
                newName: "CoursesCourseId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "CourseDepartment",
                newName: "DepartmentsDepartmentId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseDepartment",
                newName: "CoursesCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentsDepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "QDegree",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "QType",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesCourseId",
                table: "CourseDepartment",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDepartmentId",
                table: "CourseDepartment",
                column: "DepartmentsDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourseId",
                table: "CourseInstructor",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestion_Courses_CoursesCourseId",
                table: "CourseQuestion",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestion_Questions_QuestionsQuestionId",
                table: "CourseQuestion",
                column: "QuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
