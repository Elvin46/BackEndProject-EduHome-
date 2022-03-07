using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome_BackEndProject_.Migrations
{
    public partial class CreateEventsAndTeachersTablesAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LanguagePercent = table.Column<int>(type: "int", nullable: false),
                    TeamLeaderPercent = table.Column<int>(type: "int", nullable: false),
                    DevelopmentPercent = table.Column<int>(type: "int", nullable: false),
                    DesignPercent = table.Column<int>(type: "int", nullable: false),
                    InnovationPercent = table.Column<int>(type: "int", nullable: false),
                    CommunicationPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsTeachers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsTeachers_EventId",
                table: "EventsTeachers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsTeachers_TeacherId",
                table: "EventsTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsTeachers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
