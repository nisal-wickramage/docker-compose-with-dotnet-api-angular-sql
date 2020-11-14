using Microsoft.EntityFrameworkCore.Migrations;

namespace dataaccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ecom");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "ecom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ecom",
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Bread", 2 });

            migrationBuilder.InsertData(
                schema: "ecom",
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Choclate", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "ecom");
        }
    }
}
