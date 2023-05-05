using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class DiscountRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "money",
                nullable: true);
        }
    }
}
