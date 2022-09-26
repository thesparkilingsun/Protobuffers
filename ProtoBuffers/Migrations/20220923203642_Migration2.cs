using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProtoBuffers.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "OrderData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "OrderData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "OrderData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "OrderNumber", "Time" },
                values: new object[] { new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), "3745896", new DateTime(2022, 9, 23, 15, 36, 42, 419, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "OrderData",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Date", "OrderNumber", "Time" },
                values: new object[] { new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), "3745896", new DateTime(2022, 9, 23, 15, 36, 42, 419, DateTimeKind.Local).AddTicks(9337) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "OrderData");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "OrderData");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "OrderData");
        }
    }
}
