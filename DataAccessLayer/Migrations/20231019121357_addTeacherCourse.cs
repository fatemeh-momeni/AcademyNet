using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addTeacherCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Human",
                table: "Human");

            migrationBuilder.RenameTable(
                name: "Human",
                newName: "Human");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Human",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Human",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Human",
                table: "Human",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalTime = table.Column<float>(type: "real", nullable: false),
                    Descript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoIntro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoursesDetailFile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDetailFile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoursesDetailFile_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Human_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Human",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Human_CourseID",
                table: "Human",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesDetailFile_CourseID",
                table: "CoursesDetailFile",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Human_Courses_CourseID",
                table: "Human",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Human_Courses_CourseID",
                table: "Human");

            migrationBuilder.DropTable(
                name: "CoursesDetailFile");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Human",
                table: "Human");

            migrationBuilder.DropIndex(
                name: "IX_Human_CourseID",
                table: "Human");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Human");

            migrationBuilder.RenameTable(
                name: "Human",
                newName: "humans");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "humans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_humans",
                table: "humans",
                column: "Id");
        }
    }
}
