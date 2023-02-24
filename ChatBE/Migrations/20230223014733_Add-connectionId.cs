using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatBE.Migrations
{
    public partial class AddconnectionId : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f71749f-c6cb-47d5-b8b1-cc0747e218a2", "2343c166-c37e-4e5b-9ac7-fde83059f3ce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ad4d073-8744-4644-9e6e-33739d9bc0e3", "927ee3e6-507a-47cf-9408-86480c2efdd8", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f71749f-c6cb-47d5-b8b1-cc0747e218a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ad4d073-8744-4644-9e6e-33739d9bc0e3");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "AspNetUsers");

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
