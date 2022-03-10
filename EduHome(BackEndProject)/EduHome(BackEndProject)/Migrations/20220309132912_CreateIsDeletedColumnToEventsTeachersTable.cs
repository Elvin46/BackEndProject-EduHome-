using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome_BackEndProject_.Migrations
{
    public partial class CreateIsDeletedColumnToEventsTeachersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventsTeachers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventsTeachers");
        }
    }
}
