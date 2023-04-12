using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class TableandServiceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "TableModel");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "TableModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "ServiceModel",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAt",
                table: "ServiceModel",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TableModel_ServiceId",
                table: "TableModel",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_WaiterId",
                table: "ServiceModel",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_WaiterModel_WaiterId",
                table: "ServiceModel",
                column: "WaiterId",
                principalTable: "WaiterModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableModel_ServiceModel_ServiceId",
                table: "TableModel",
                column: "ServiceId",
                principalTable: "ServiceModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_WaiterModel_WaiterId",
                table: "ServiceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TableModel_ServiceModel_ServiceId",
                table: "TableModel");

            migrationBuilder.DropIndex(
                name: "IX_TableModel_ServiceId",
                table: "TableModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_WaiterId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "TableModel");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "ServiceModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAt",
                table: "TableModel",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
