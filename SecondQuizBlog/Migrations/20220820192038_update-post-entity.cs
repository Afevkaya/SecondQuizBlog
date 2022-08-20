using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondQuizBlog.Migrations
{
    public partial class updatepostentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Posts",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ContentText",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentText",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Posts",
                newName: "Detail");
        }
    }
}
