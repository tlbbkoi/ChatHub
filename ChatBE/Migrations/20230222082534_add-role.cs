using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatBE.Migrations
{
    public partial class addrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a54d0fd-3544-4272-945f-9ac78f886276", "7036c2c4-0778-43d9-bc41-b7549fe9319e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae997bfe-2a5d-4e66-8d24-333da6e26a58", "93eaf3c7-30fd-45a9-ba7e-21966b3eccaf", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a54d0fd-3544-4272-945f-9ac78f886276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae997bfe-2a5d-4e66-8d24-333da6e26a58");
        }
    }
}
