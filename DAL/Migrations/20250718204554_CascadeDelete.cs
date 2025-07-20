using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_UserInfo_RequestedBy",
                table: "UserRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_UserInfo_RequestedBy",
                table: "UserRequests",
                column: "RequestedBy",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_UserInfo_RequestedBy",
                table: "UserRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_UserInfo_RequestedBy",
                table: "UserRequests",
                column: "RequestedBy",
                principalTable: "UserInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
