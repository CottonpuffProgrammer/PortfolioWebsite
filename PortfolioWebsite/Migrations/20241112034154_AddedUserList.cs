using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotolioUserId",
                table: "Photos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotolioUserId",
                table: "Photos",
                column: "PhotolioUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_PhotolioUserId",
                table: "Photos",
                column: "PhotolioUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_PhotolioUserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotolioUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotolioUserId",
                table: "Photos");
        }
    }
}
