using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class createRelationBetweenBookAndCategoryMto1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6be11f7c-2f5a-4dfd-8221-d2213592ce20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be72c612-b3e0-42d1-a64d-bf5356cdd4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e3efac-f671-4eab-9f24-7190f962b12e");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c89d98b-37c2-4938-88eb-9ea038690e16", "89c7a3cb-e54c-496f-b787-51f707bc008d", "Admin", "ADMIN" },
                    { "9aa89ef6-cc09-4f86-ac18-32b3da9f6b3e", "5e49b91d-32e3-4a69-8eb5-13b697a7325e", "User", "USER" },
                    { "f301195f-83bb-415a-a017-f90a889dab79", "c27845d7-2cce-4aa6-8f07-6f5408d578c2", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c89d98b-37c2-4938-88eb-9ea038690e16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa89ef6-cc09-4f86-ac18-32b3da9f6b3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f301195f-83bb-415a-a017-f90a889dab79");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6be11f7c-2f5a-4dfd-8221-d2213592ce20", "7b146e97-b57f-435d-aa67-9bfeac0eb5df", "User", "USER" },
                    { "be72c612-b3e0-42d1-a64d-bf5356cdd4fa", "72113564-5328-44e6-b57f-b9aca80ffed4", "Admin", "ADMIN" },
                    { "c2e3efac-f671-4eab-9f24-7190f962b12e", "c25d05fe-b089-479f-9b39-e9402af33fe9", "Editor", "EDITOR" }
                });
        }
    }
}
