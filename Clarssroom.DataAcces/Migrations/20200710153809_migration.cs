using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Classroom.DataAcces.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PhoneNr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassroomId = table.Column<Guid>(nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    DueTo = table.Column<DateTime>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requires",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassroomIdId = table.Column<Guid>(nullable: true),
                    StudentIdUserId = table.Column<Guid>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requires_Classrooms_ClassroomIdId",
                        column: x => x.ClassroomIdId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requires_Users_StudentIdUserId",
                        column: x => x.StudentIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    StudentIdUserId = table.Column<Guid>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Homeworks_Users_StudentIdUserId",
                        column: x => x.StudentIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeworkId = table.Column<Guid>(nullable: true),
                    StudentIdUserId = table.Column<Guid>(nullable: true),
                    Mark = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentIdUserId",
                        column: x => x.StudentIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassroomId",
                table: "Assignments",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_HomeworkId",
                table: "Grades",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentIdUserId",
                table: "Grades",
                column: "StudentIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_AssignmentId",
                table: "Homeworks",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentIdUserId",
                table: "Homeworks",
                column: "StudentIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requires_ClassroomIdId",
                table: "Requires",
                column: "ClassroomIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Requires_StudentIdUserId",
                table: "Requires",
                column: "StudentIdUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Requires");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
