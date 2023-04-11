using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryModel_ProductModel_ProductModelId",
                table: "CategoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_ServiceModel_ServiceModelId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_ServiceModelId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_CategoryModel_ProductModelId",
                table: "CategoryModel");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "ServiceModelId",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "CategoryModel");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductModelServiceModel",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelServiceModel", x => new { x.ProductsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ProductModelServiceModel_ProductModel_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelServiceModel_ServiceModel_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "ServiceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceModelWaiterModel",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "INTEGER", nullable: false),
                    WaitersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModelWaiterModel", x => new { x.ServicesId, x.WaitersId });
                    table.ForeignKey(
                        name: "FK_ServiceModelWaiterModel_ServiceModel_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "ServiceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceModelWaiterModel_WaiterModel_WaitersId",
                        column: x => x.WaitersId,
                        principalTable: "WaiterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_TableId",
                table: "ServiceModel",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_CategoryId",
                table: "ProductModel",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelServiceModel_ServicesId",
                table: "ProductModelServiceModel",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModelWaiterModel_WaitersId",
                table: "ServiceModelWaiterModel",
                column: "WaitersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryId",
                table: "ProductModel",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_TableModel_TableId",
                table: "ServiceModel",
                column: "TableId",
                principalTable: "TableModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_TableModel_TableId",
                table: "ServiceModel");

            migrationBuilder.DropTable(
                name: "ProductModelServiceModel");

            migrationBuilder.DropTable(
                name: "ServiceModelWaiterModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_TableId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_CategoryId",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductModel");

            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "ServiceModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceModelId",
                table: "ProductModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "CategoryModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_ServiceModelId",
                table: "ProductModel",
                column: "ServiceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModel_ProductModelId",
                table: "CategoryModel",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryModel_ProductModel_ProductModelId",
                table: "CategoryModel",
                column: "ProductModelId",
                principalTable: "ProductModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_ServiceModel_ServiceModelId",
                table: "ProductModel",
                column: "ServiceModelId",
                principalTable: "ServiceModel",
                principalColumn: "Id");
        }
    }
}
