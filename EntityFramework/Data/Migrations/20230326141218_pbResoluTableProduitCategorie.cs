using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Data.Migrations
{
    /// <inheritdoc />
    public partial class pbResoluTableProduitCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProduitCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProduitCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
