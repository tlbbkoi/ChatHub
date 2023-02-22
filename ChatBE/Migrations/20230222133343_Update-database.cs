using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatBE.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a54d0fd-3544-4272-945f-9ac78f886276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae997bfe-2a5d-4e66-8d24-333da6e26a58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27660b33-4176-4d5f-833f-401e123fca7e", "5d5f034c-6f8c-4c24-8202-ae89167aa624", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a424599a-ef1e-468a-872f-e871ee72fa86", "e4dd34b0-9744-4996-ae28-fd39b89892df", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27660b33-4176-4d5f-833f-401e123fca7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a424599a-ef1e-468a-872f-e871ee72fa86");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a54d0fd-3544-4272-945f-9ac78f886276", "7036c2c4-0778-43d9-bc41-b7549fe9319e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae997bfe-2a5d-4e66-8d24-333da6e26a58", "93eaf3c7-30fd-45a9-ba7e-21966b3eccaf", "Administrator", "ADMINISTRATOR" });
        }
    }
}
