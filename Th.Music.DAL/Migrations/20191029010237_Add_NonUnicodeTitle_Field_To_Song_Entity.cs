using Microsoft.EntityFrameworkCore.Migrations;

namespace Th.Music.DAL.Migrations
{
    public partial class Add_NonUnicodeTitle_Field_To_Song_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NonUnicodeTitle",
                table: "Songs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NonUnicodeTitle",
                table: "Songs");
        }
    }
}
