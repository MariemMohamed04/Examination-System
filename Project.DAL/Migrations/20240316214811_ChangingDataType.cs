using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestions_Courses_CourseId",
                table: "CourseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestions_Questions_QuestionId",
                table: "CourseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CourseQuestions_QuestionId",
                table: "CourseQuestions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "NumOfQuestions",
                table: "Exams",
                newName: "Num_TF_Questions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Num_MCQ_Questions",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CourseId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Num_MCQ_Questions",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Num_TF_Questions",
                table: "Exams",
                newName: "NumOfQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuestions_QuestionId",
                table: "CourseQuestions",
                column: "QuestionId");

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
        }
    }
}
