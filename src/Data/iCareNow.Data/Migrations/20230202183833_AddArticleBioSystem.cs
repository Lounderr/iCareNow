using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iCareNow.Data.Migrations
{
    public partial class AddArticleBioSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BioSystem",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BioSystem",
                table: "Articles");
        }
    }
}
