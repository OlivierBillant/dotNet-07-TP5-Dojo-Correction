using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpDojo.Dal.Migrations
{
    public partial class ArmeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samourai_Arme_ArmeId",
                table: "Samourai");

            migrationBuilder.AlterColumn<int>(
                name: "ArmeId",
                table: "Samourai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Samourai_Arme_ArmeId",
                table: "Samourai",
                column: "ArmeId",
                principalTable: "Arme",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samourai_Arme_ArmeId",
                table: "Samourai");

            migrationBuilder.AlterColumn<int>(
                name: "ArmeId",
                table: "Samourai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samourai_Arme_ArmeId",
                table: "Samourai",
                column: "ArmeId",
                principalTable: "Arme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
