using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriculturalProducts.Repository.Data.Migrations
{
    public partial class AddCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comments");
        }
    }
}
