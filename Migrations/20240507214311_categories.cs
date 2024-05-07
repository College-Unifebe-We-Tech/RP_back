using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP_back.Migrations
{
    /// <inheritdoc />
    public partial class categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('calçado')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('bolsa')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('camisa')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('garrafa')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName) VALUES ('mouse')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
