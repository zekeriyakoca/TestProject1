using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class AddFieldsToFileAndNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_FileId",
                table: "Notes",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Files_FileId",
                table: "Notes",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Files_FileId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_FileId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Files");
        }
    }
}
