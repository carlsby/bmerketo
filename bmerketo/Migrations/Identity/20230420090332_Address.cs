using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_UserAddressEntity_AddressId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddressEntity",
                table: "UserAddressEntity");

            migrationBuilder.RenameTable(
                name: "UserAddressEntity",
                newName: "UserAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_UserAddress_AddressId",
                table: "UserProfiles",
                column: "AddressId",
                principalTable: "UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_UserAddress_AddressId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.RenameTable(
                name: "UserAddress",
                newName: "UserAddressEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddressEntity",
                table: "UserAddressEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_UserAddressEntity_AddressId",
                table: "UserProfiles",
                column: "AddressId",
                principalTable: "UserAddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
