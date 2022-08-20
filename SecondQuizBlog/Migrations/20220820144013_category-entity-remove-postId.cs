using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondQuizBlog.Migrations
{
    public partial class categoryentityremovepostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
