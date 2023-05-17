using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class Tagbuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductEntityId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagEntityId",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductTags_ProductEntityId",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "ProductTags");

            migrationBuilder.RenameColumn(
                name: "TagEntityId",
                table: "ProductTags",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagEntityId",
                table: "ProductTags",
                newName: "IX_ProductTags_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductTags",
                newName: "TagEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagEntityId");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "ProductTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductEntityId",
                table: "ProductTags",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductEntityId",
                table: "ProductTags",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagEntityId",
                table: "ProductTags",
                column: "TagEntityId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
