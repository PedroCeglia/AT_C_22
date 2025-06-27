using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_C__2.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToCliente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clientes");
        }
    }
}
