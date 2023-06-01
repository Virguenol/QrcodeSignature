using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grs.BioRestock.Infrastructure.Migrations
{
    public partial class _00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "DemandeSignature",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "DemandeSignature");
        }
    }
}
