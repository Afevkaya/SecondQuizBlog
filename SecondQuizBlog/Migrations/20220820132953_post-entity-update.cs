using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondQuizBlog.Migrations
{
    public partial class postentityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Posts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Name");
        }
    }
}
