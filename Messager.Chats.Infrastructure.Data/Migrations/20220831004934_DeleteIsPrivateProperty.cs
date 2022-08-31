using Microsoft.EntityFrameworkCore.Migrations;

namespace Messager.Chats.Infrastructure.Data.Migrations
{
    public partial class DeleteIsPrivateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Chats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Chats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
