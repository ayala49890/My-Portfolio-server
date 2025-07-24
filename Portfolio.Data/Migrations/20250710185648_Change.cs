using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Skills_SkillId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_SkillId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SkillId",
                table: "Projects",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Skills_SkillId",
                table: "Projects",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
