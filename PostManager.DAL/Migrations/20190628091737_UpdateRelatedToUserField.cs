using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostManager.DAL.Migrations
{
    public partial class UpdateRelatedToUserField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RelatedToUser",
                table: "Feeds",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RelatedToUser",
                table: "Feeds",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
