using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EXLtestApp.Migrations
{
    public partial class initialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmpEndDate", "EmpStartDate", "JobTitle", "Name" },
                values: new object[] { 1, 35, null, new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Developer", "Patric Jhons" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmpEndDate", "EmpStartDate", "JobTitle", "Name" },
                values: new object[] { 2, 30, null, new DateTime(2012, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Developer", "Alen Mark" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmpEndDate", "EmpStartDate", "JobTitle", "Name" },
                values: new object[] { 3, 37, null, new DateTime(2016, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Developer", "Nila Jhonson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
