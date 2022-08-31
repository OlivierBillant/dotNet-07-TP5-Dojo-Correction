using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpDojo.Dal.Migrations
{
    public partial class AddArtMartiauxMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtMartiaux_Samourai_SamouraiId",
                table: "ArtMartiaux");

            migrationBuilder.DropIndex(
                name: "IX_ArtMartiaux_SamouraiId",
                table: "ArtMartiaux");

            migrationBuilder.DropColumn(
                name: "SamouraiId",
                table: "ArtMartiaux");

            migrationBuilder.CreateTable(
                name: "ArtMartialSamourai",
                columns: table => new
                {
                    ArtMartiauxId = table.Column<int>(type: "int", nullable: false),
                    SamouraisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMartialSamourai", x => new { x.ArtMartiauxId, x.SamouraisId });
                    table.ForeignKey(
                        name: "FK_ArtMartialSamourai_ArtMartiaux_ArtMartiauxId",
                        column: x => x.ArtMartiauxId,
                        principalTable: "ArtMartiaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtMartialSamourai_Samourai_SamouraisId",
                        column: x => x.SamouraisId,
                        principalTable: "Samourai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtMartialSamourai_SamouraisId",
                table: "ArtMartialSamourai",
                column: "SamouraisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtMartialSamourai");

            migrationBuilder.AddColumn<int>(
                name: "SamouraiId",
                table: "ArtMartiaux",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtMartiaux_SamouraiId",
                table: "ArtMartiaux",
                column: "SamouraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtMartiaux_Samourai_SamouraiId",
                table: "ArtMartiaux",
                column: "SamouraiId",
                principalTable: "Samourai",
                principalColumn: "Id");
        }
    }
}
