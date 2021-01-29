using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_project.Migrations
{
    public partial class add_skill_and_charactorSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Damage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharactorSkill",
                columns: table => new
                {
                    CharactorId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactorSkill", x => new { x.CharactorId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharactorSkill_Charactor_CharactorId",
                        column: x => x.CharactorId,
                        principalTable: "Charactor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactorSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactorSkill_SkillId",
                table: "CharactorSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactorSkill");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
