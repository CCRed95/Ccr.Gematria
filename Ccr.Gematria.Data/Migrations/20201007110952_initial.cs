using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccr.Gematria.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "GematriaResults",
                schema: "dbo",
                columns: table => new
                {
                    GematriaResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 300, nullable: false),
                    EnglishOrdinal = table.Column<int>(nullable: false),
                    ReverseOrdinal = table.Column<int>(nullable: false),
                    FullReduction = table.Column<int>(nullable: false),
                    ReverseFullReduction = table.Column<int>(nullable: false),
                    Jewish = table.Column<int>(nullable: false),
                    FibonacciSequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GematriaResults", x => x.GematriaResultID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GematriaResults",
                schema: "dbo");
        }
    }
}
