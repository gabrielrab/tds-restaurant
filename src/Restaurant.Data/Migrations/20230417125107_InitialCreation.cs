using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(type: "TEXT", nullable: false),
                        Description = table.Column<string>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "TableModel",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Code = table.Column<int>(type: "INTEGER", nullable: false),
                        Status = table.Column<bool>(type: "INTEGER", nullable: false),
                        StartAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableModel", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "WaiterModel",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        FirstName = table.Column<string>(type: "TEXT", nullable: false),
                        LastName = table.Column<string>(type: "TEXT", nullable: false),
                        Code = table.Column<int>(type: "INTEGER", nullable: false),
                        Phone = table.Column<string>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterModel", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(type: "TEXT", nullable: false),
                        Description = table.Column<string>(type: "TEXT", nullable: false),
                        Price = table.Column<double>(type: "REAL", nullable: false),
                        CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModel_CategoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryModel",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ServiceModel",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        TableId = table.Column<int>(type: "INTEGER", nullable: false),
                        StartAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                        EndAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceModel_TableModel_TableId",
                        column: x => x.TableId,
                        principalTable: "TableModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ServiceLines",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                        TableId = table.Column<int>(type: "INTEGER", nullable: false),
                        ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                        WaiterId = table.Column<int>(type: "INTEGER", nullable: false),
                        Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceLines_ProductModel_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ServiceLines_ServiceModel_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ServiceLines_TableModel_TableId",
                        column: x => x.TableId,
                        principalTable: "TableModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ServiceLines_WaiterModel_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "WaiterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_CategoryId",
                table: "ProductModel",
                column: "CategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLines_ProductId",
                table: "ServiceLines",
                column: "ProductId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLines_ServiceId",
                table: "ServiceLines",
                column: "ServiceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLines_TableId",
                table: "ServiceLines",
                column: "TableId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLines_WaiterId",
                table: "ServiceLines",
                column: "WaiterId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_TableId",
                table: "ServiceModel",
                column: "TableId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ServiceLines");

            migrationBuilder.DropTable(name: "ProductModel");

            migrationBuilder.DropTable(name: "ServiceModel");

            migrationBuilder.DropTable(name: "WaiterModel");

            migrationBuilder.DropTable(name: "CategoryModel");

            migrationBuilder.DropTable(name: "TableModel");
        }
    }
}
