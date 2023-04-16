using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StudentId", "Name", "Roll" },
                values: new object[,]
                {
                    { new Guid("38b69e88-e7bf-4fec-b582-c9636fd66bc7"), "Student1", "1001" },
                    { new Guid("3c4c04e0-5f49-452a-9468-f4056578358b"), "Student2", "1002" },
                    { new Guid("fa8533a2-0897-4279-b0fa-46a4a3a54b74"), "Student3", "1003" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: new Guid("38b69e88-e7bf-4fec-b582-c9636fd66bc7"));

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: new Guid("3c4c04e0-5f49-452a-9468-f4056578358b"));

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: new Guid("fa8533a2-0897-4279-b0fa-46a4a3a54b74"));
        }
    }
}
