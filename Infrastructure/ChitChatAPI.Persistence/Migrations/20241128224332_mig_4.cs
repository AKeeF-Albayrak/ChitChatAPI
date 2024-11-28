using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChitChatAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_UserId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_UserId1",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_GroupMessages_GroupMessageId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMessages_UserId",
                table: "GroupMessages");

            migrationBuilder.DropIndex(
                name: "IX_GroupMessages_UserId1",
                table: "GroupMessages");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupMessages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "GroupMessages");

            migrationBuilder.AddColumn<bool>(
                name: "PasswordResetAuthorized",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetAuthorizedExpiration",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationCodeExpiration",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "GroupUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Groups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers",
                columns: new[] { "GroupId", "UserId" });

            migrationBuilder.CreateTable(
                name: "MessageReads",
                columns: table => new
                {
                    ReadedUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceivedMessagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReads", x => new { x.ReadedUsersId, x.ReceivedMessagesId });
                    table.ForeignKey(
                        name: "FK_MessageReads_GroupMessages_ReceivedMessagesId",
                        column: x => x.ReceivedMessagesId,
                        principalTable: "GroupMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReads_Users_ReadedUsersId",
                        column: x => x.ReadedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatedById",
                table: "Groups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReads_ReceivedMessagesId",
                table: "MessageReads",
                column: "ReceivedMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatedById",
                table: "Groups",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_GroupMessages_GroupMessageId",
                table: "Notifications",
                column: "GroupMessageId",
                principalTable: "GroupMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatedById",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_GroupMessages_GroupMessageId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "MessageReads");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedById",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PasswordResetAuthorized",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordResetAuthorizedExpiration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationCodeExpiration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "GroupUsers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Groups");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GroupMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "GroupMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_UserId",
                table: "GroupMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_UserId1",
                table: "GroupMessages",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_UserId",
                table: "GroupMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_UserId1",
                table: "GroupMessages",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_GroupMessages_GroupMessageId",
                table: "Notifications",
                column: "GroupMessageId",
                principalTable: "GroupMessages",
                principalColumn: "Id");
        }
    }
}
