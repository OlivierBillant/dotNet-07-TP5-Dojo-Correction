using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpDojo.Dal.Migrations
{
    public partial class AddImageArme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Arme",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Arme");
        }
    }
}
