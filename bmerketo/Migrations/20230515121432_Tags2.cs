using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class Tags2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_Products_ProductEntityId",
                table: "ProductTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_TagEntity_TagEntityId",
                table: "ProductTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagEntity",
                table: "TagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity");

            migrationBuilder.RenameTable(
                name: "TagEntity",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "ProductTagEntity",
                newName: "ProductTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_TagEntityId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_ProductEntityId",
                table: "ProductTags",
                newName: "IX_ProductTags_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductEntityId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagEntityId",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "TagEntity");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "ProductTagEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagEntityId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_TagEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_ProductEntityId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagEntity",
                table: "TagEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_Products_ProductEntityId",
                table: "ProductTagEntity",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_TagEntity_TagEntityId",
                table: "ProductTagEntity",
                column: "TagEntityId",
                principalTable: "TagEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
