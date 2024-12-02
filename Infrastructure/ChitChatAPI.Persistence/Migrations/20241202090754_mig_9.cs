using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChitChatAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Groups",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Groups");
        }
    }
}
