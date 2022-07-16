using Microsoft.EntityFrameworkCore.Migrations;

namespace Messager.Chats.Infrastructure.Data.Migrations
{
    public partial class SetPrimaryKeyToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMembers",
                table: "ChatMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMembers",
                table: "ChatMembers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMembers",
                table: "ChatMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMembers",
                table: "ChatMembers",
                column: "UserId");
        }
    }
}
