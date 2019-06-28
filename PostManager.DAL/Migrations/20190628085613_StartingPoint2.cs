using Microsoft.EntityFrameworkCore.Migrations;

namespace PostManager.DAL.Migrations
{
    public partial class StartingPoint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_Feeds_RelatedToUser",
            //    table: "Feeds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Feeds_RelatedToUser",
                table: "Feeds",
                column: "RelatedToUser",
                unique: true);
        }
    }
}
