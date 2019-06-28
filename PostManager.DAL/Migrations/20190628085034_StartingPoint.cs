using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostManager.DAL.Migrations
{
    public partial class StartingPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Feeds");

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedToUser",
                table: "Feeds",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feeds_RelatedToUser",
            //    table: "Feeds",
            //    column: "RelatedToUser",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feeds_RelatedToUser",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "RelatedToUser",
                table: "Feeds");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Feeds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_UserID",
                table: "Feeds",
                column: "UserID",
                unique: true);
        }
    }
}
