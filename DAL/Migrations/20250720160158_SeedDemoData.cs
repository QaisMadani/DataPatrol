using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PolicyTable",
                columns: new[] { "PolicyId", "CreatedDateTime", "IsDefault", "IsEnabled", "PolicyName", "PolicyType" },
                values: new object[,]
                {
                    { "P1", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, "DefaultPolicy", 0 },
                    { "P2", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "StrictPolicy", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "GroupId", "Description" },
                values: new object[,]
                {
                    { "admins", "Administrators" },
                    { "reviewers", "Request Reviewers" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserId", "CreatedDateTime", "IsEnabled", "Username" },
                values: new object[,]
                {
                    { "ahmad", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ahmad" },
                    { "ali", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ali" },
                    { "farah", new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Farah" },
                    { "mehdi", new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mehdi" },
                    { "qais", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Qais" },
                    { "sara", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sara" },
                    { "sulaiman", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sulaiman" }
                });

            migrationBuilder.InsertData(
                table: "PolicyUserGroups",
                columns: new[] { "GroupId", "PolicyId" },
                values: new object[,]
                {
                    { "admins", "P1" },
                    { "reviewers", "P2" }
                });

            migrationBuilder.InsertData(
                table: "UserRequests",
                columns: new[] { "RequestId", "CompletionDateTime", "Description", "RequestCode", "RequestDateTime", "RequestedBy", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 7, 8, 9, 5, 0, 0, DateTimeKind.Unspecified), "Initial system setup", 100, new DateTime(2025, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "qais", 2 },
                    { 2L, null, "Documentation review", 101, new DateTime(2025, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), "ali", 1 },
                    { 3L, null, "Feature design", 102, new DateTime(2025, 7, 9, 9, 30, 0, 0, DateTimeKind.Unspecified), "mehdi", 0 },
                    { 4L, new DateTime(2025, 7, 9, 10, 45, 0, 0, DateTimeKind.Unspecified), "Performance audit", 103, new DateTime(2025, 7, 9, 10, 15, 0, 0, DateTimeKind.Unspecified), "farah", 3 },
                    { 5L, null, "Security scan", 104, new DateTime(2025, 7, 10, 8, 45, 0, 0, DateTimeKind.Unspecified), "sara", 4 },
                    { 6L, new DateTime(2025, 7, 10, 11, 10, 0, 0, DateTimeKind.Unspecified), "User training", 105, new DateTime(2025, 7, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "ahmad", 2 },
                    { 7L, null, "Final review", 106, new DateTime(2025, 7, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "sulaiman", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserUserGroups",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { "admins", "ahmad" },
                    { "reviewers", "ali" },
                    { "admins", "farah" },
                    { "reviewers", "mehdi" },
                    { "admins", "qais" },
                    { "reviewers", "sara" },
                    { "reviewers", "sulaiman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PolicyUserGroups",
                keyColumns: new[] { "GroupId", "PolicyId" },
                keyValues: new object[] { "admins", "P1" });

            migrationBuilder.DeleteData(
                table: "PolicyUserGroups",
                keyColumns: new[] { "GroupId", "PolicyId" },
                keyValues: new object[] { "reviewers", "P2" });

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "UserRequests",
                keyColumn: "RequestId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "admins", "ahmad" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "reviewers", "ali" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "admins", "farah" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "reviewers", "mehdi" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "admins", "qais" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "reviewers", "sara" });

            migrationBuilder.DeleteData(
                table: "UserUserGroups",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { "reviewers", "sulaiman" });

            migrationBuilder.DeleteData(
                table: "PolicyTable",
                keyColumn: "PolicyId",
                keyValue: "P1");

            migrationBuilder.DeleteData(
                table: "PolicyTable",
                keyColumn: "PolicyId",
                keyValue: "P2");

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "GroupId",
                keyValue: "admins");

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "GroupId",
                keyValue: "reviewers");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "ahmad");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "ali");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "farah");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "mehdi");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "qais");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "sara");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "UserId",
                keyValue: "sulaiman");
        }
    }
}
