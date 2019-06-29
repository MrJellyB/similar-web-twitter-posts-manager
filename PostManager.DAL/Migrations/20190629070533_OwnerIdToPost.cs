using Microsoft.EntityFrameworkCore.Migrations;

namespace PostManager.DAL.Migrations
{
    public partial class OwnerIdToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Posts");
        }
    }
}
