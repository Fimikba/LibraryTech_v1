using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryTechWebApp.Migrations
{
    public partial class AddFieldToAppUserModelV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserModelBook_AspNetUsers_UserId",
                table: "AppUserModelBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserModelBook_Books_BooksBookId",
                table: "AppUserModelBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserModelBook",
                table: "AppUserModelBook");

            migrationBuilder.RenameTable(
                name: "AppUserModelBook",
                newName: "BookUser");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserModelBook_UserId",
                table: "BookUser",
                newName: "IX_BookUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser",
                columns: new[] { "BooksBookId", "UserId" });

            migrationBuilder.CreateTable(
                name: "BookUserBySubs",
                columns: table => new
                {
                    ReadRecentlyBySubsBookId = table.Column<int>(type: "int", nullable: false),
                    UserHowRecentlyReadBySubsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserBySubs", x => new { x.ReadRecentlyBySubsBookId, x.UserHowRecentlyReadBySubsId });
                    table.ForeignKey(
                        name: "FK_BookUserBySubs_AspNetUsers_UserHowRecentlyReadBySubsId",
                        column: x => x.UserHowRecentlyReadBySubsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserBySubs_Books_ReadRecentlyBySubsBookId",
                        column: x => x.ReadRecentlyBySubsBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUserBySubs_UserHowRecentlyReadBySubsId",
                table: "BookUserBySubs",
                column: "UserHowRecentlyReadBySubsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId",
                table: "BookUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Books_BooksBookId",
                table: "BookUser",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId",
                table: "BookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Books_BooksBookId",
                table: "BookUser");

            migrationBuilder.DropTable(
                name: "BookUserBySubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser");

            migrationBuilder.RenameTable(
                name: "BookUser",
                newName: "AppUserModelBook");

            migrationBuilder.RenameIndex(
                name: "IX_BookUser_UserId",
                table: "AppUserModelBook",
                newName: "IX_AppUserModelBook_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserModelBook",
                table: "AppUserModelBook",
                columns: new[] { "BooksBookId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserModelBook_AspNetUsers_UserId",
                table: "AppUserModelBook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserModelBook_Books_BooksBookId",
                table: "AppUserModelBook",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
