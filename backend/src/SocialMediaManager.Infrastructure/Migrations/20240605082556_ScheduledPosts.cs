using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScheduledPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242fef0c-6cf6-43ba-8b40-74af4adfbb9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3138eacc-da5d-4e71-9396-458f3a341e70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c1cc2ef-3275-4c89-ad19-9437e652a5ba", null, "Admin", "ADMIN" },
                    { "a1ea8c1a-a30b-49a6-9d07-af113760e275", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c1cc2ef-3275-4c89-ad19-9437e652a5ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ea8c1a-a30b-49a6-9d07-af113760e275");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "242fef0c-6cf6-43ba-8b40-74af4adfbb9f", null, "User", "USER" },
                    { "3138eacc-da5d-4e71-9396-458f3a341e70", null, "Admin", "ADMIN" }
                });
        }
    }
}
