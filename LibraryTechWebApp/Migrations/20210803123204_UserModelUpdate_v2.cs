using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryTechWebApp.Migrations
{
    public partial class UserModelUpdate_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUserBySubs_AspNetUsers_UserHowRecentlyReadBySubsId",
                table: "BookUserBySubs");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUserBySubs_Books_ReadRecentlyBySubsBookId",
                table: "BookUserBySubs");

            migrationBuilder.RenameColumn(
                name: "UserHowRecentlyReadBySubsId",
                table: "BookUserBySubs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReadRecentlyBySubsBookId",
                table: "BookUserBySubs",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookUserBySubs_UserHowRecentlyReadBySubsId",
                table: "BookUserBySubs",
                newName: "IX_BookUserBySubs_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastRead",
                table: "BookUserBySubs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserBySubs_AspNetUsers_UserId",
                table: "BookUserBySubs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserBySubs_Books_BookId",
                table: "BookUserBySubs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUserBySubs_AspNetUsers_UserId",
                table: "BookUserBySubs");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUserBySubs_Books_BookId",
                table: "BookUserBySubs");

            migrationBuilder.DropColumn(
                name: "DateLastRead",
                table: "BookUserBySubs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BookUserBySubs",
                newName: "UserHowRecentlyReadBySubsId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookUserBySubs",
                newName: "ReadRecentlyBySubsBookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookUserBySubs_UserId",
                table: "BookUserBySubs",
                newName: "IX_BookUserBySubs_UserHowRecentlyReadBySubsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserBySubs_AspNetUsers_UserHowRecentlyReadBySubsId",
                table: "BookUserBySubs",
                column: "UserHowRecentlyReadBySubsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUserBySubs_Books_ReadRecentlyBySubsBookId",
                table: "BookUserBySubs",
                column: "ReadRecentlyBySubsBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
