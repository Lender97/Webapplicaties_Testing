using Microsoft.EntityFrameworkCore.Migrations;

namespace DonutQueen.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donut",
                columns: table => new
                {
                    DonutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Topping = table.Column<string>(nullable: false),
                    Glazuur = table.Column<string>(nullable: false),
                    Vulling = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    IsVegan = table.Column<bool>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donut", x => x.DonutId);
                });

            migrationBuilder.CreateTable(
                name: "Winkel",
                columns: table => new
                {
                    WinkelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Straat = table.Column<string>(nullable: true),
                    Nummer = table.Column<int>(nullable: false),
                    Gemeente = table.Column<string>(nullable: true),
                    Postcode = table.Column<int>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkel", x => x.WinkelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donut");

            migrationBuilder.DropTable(
                name: "Winkel");
        }
    }
}
