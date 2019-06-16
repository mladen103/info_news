using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class relationbetweenpictureandstoryupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Stories_StoryId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_StoryId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Pictures");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_PictureId",
                table: "Stories",
                column: "PictureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Pictures_PictureId",
                table: "Stories",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Pictures_PictureId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_PictureId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Stories");

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Pictures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_StoryId",
                table: "Pictures",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Stories_StoryId",
                table: "Pictures",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
