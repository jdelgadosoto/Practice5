using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingPurchaseTableAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "PurchaseId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 301, "Arizona", 400 },
                    { 302, "Cheetos", 500 },
                    { 303, "Sabritones", 200 },
                    { 304, "Boing", 400 },
                    { 305, "Chokis", 300 },
                    { 306, "Sabritones", 500 },
                    { 307, "Chokis", 450 },
                    { 308, "Totis", 300 },
                    { 309, "Cheetos", 250 },
                    { 310, "Totis", 350 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
