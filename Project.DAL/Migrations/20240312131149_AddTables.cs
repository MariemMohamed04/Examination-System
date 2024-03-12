using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_CourseInstructor_Instructors_InstructorId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Courses_CourseId",
                table: "CourseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestion_Questions_QuestionId",
                table: "CourseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseQuestion",
                table: "CourseQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructor",
                table: "CourseInstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment");

            migrationBuilder.RenameTable(
                name: "ExamQuestion",
                newName: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "CourseQuestion",
                newName: "CourseQuestions");

            migrationBuilder.RenameTable(
                name: "CourseInstructor",
                newName: "CourseInstructors");

            migrationBuilder.RenameTable(
                name: "CourseDepartment",
                newName: "CourseDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseQuestion_QuestionId",
                table: "CourseQuestions",
                newName: "IX_CourseQuestions_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructor_InstructorId",
                table: "CourseInstructors",
                newName: "IX_CourseInstructors_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentId",
                table: "CourseDepartments",
                newName: "IX_CourseDepartments_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                columns: new[] { "ExamId", "QuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseQuestions",
                table: "CourseQuestions",
                columns: new[] { "CourseId", "QuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors",
                columns: new[] { "CourseId", "InstructorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDepartments",
                table: "CourseDepartments",
                columns: new[] { "CourseId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartments_Courses_CourseId",
                table: "CourseDepartments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartments_Departments_DepartmentId",
                table: "CourseDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructors_Courses_CourseId",
                table: "CourseInstructors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructors_Instructors_InstructorId",
                table: "CourseInstructors",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestions_Courses_CourseId",
                table: "CourseQuestions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestions_Questions_QuestionId",
                table: "CourseQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartments_Courses_CourseId",
                table: "CourseDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartments_Departments_DepartmentId",
                table: "CourseDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructors_Courses_CourseId",
                table: "CourseInstructors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructors_Instructors_InstructorId",
                table: "CourseInstructors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestions_Courses_CourseId",
                table: "CourseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestions_Questions_QuestionId",
                table: "CourseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseQuestions",
                table: "CourseQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructors",
                table: "CourseInstructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDepartments",
                table: "CourseDepartments");

            migrationBuilder.RenameTable(
                name: "ExamQuestions",
                newName: "ExamQuestion");

            migrationBuilder.RenameTable(
                name: "CourseQuestions",
                newName: "CourseQuestion");

            migrationBuilder.RenameTable(
                name: "CourseInstructors",
                newName: "CourseInstructor");

            migrationBuilder.RenameTable(
                name: "CourseDepartments",
                newName: "CourseDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseQuestions_QuestionId",
                table: "CourseQuestion",
                newName: "IX_CourseQuestion_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructors_InstructorId",
                table: "CourseInstructor",
                newName: "IX_CourseInstructor_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartments_DepartmentId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion",
                columns: new[] { "ExamId", "QuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseQuestion",
                table: "CourseQuestion",
                columns: new[] { "CourseId", "QuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructor",
                table: "CourseInstructor",
                columns: new[] { "CourseId", "InstructorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment",
                columns: new[] { "CourseId", "DepartmentId" });

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
                name: "FK_CourseInstructor_Instructors_InstructorId",
                table: "CourseInstructor",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
