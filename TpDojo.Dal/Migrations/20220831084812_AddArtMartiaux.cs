using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpDojo.Dal.Migrations
{
    public partial class AddArtMartiaux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai");

            migrationBuilder.CreateTable(
                name: "ArtMartiaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SamouraiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMartiaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtMartiaux_Samourai_SamouraiId",
                        column: x => x.SamouraiId,
                        principalTable: "Samourai",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai",
                column: "ArmeId",
                unique: true,
                filter: "[ArmeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMartiaux_SamouraiId",
                table: "ArtMartiaux",
                column: "SamouraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtMartiaux");

            migrationBuilder.DropIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai");

            migrationBuilder.CreateIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai",
                column: "ArmeId");
        }
    }
}
