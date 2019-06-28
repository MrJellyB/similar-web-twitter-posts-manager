using Microsoft.EntityFrameworkCore.Migrations;

namespace PostManager.DAL.Migrations
{
    public partial class Feeds2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Feeds_FeedId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FeedId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FeedId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Feeds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FeedPost",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    FeedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedPost", x => new { x.FeedId, x.PostId });
                    table.ForeignKey(
                        name: "FK_FeedPost_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedPost_PostId",
                table: "FeedPost",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedPost");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_UserID",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Feeds");

            migrationBuilder.AddColumn<int>(
                name: "FeedId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FeedId",
                table: "Posts",
                column: "FeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Feeds_FeedId",
                table: "Posts",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "FeedId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
