using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_project.Migrations
{
    public partial class rename_firstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("FirstName","Employee","FirstNameXXX");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("FirstNameXXX","Employee","FirstName");
        }
    }
}
