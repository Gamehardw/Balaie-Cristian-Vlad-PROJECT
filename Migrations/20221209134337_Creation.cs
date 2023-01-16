using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balaie_Cristian_Vlad_PROJECT.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Valency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Metalloid",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetalloidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Valency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metalloid", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NonMetal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NonMetalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Valency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonMetal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Compound",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetalID = table.Column<int>(type: "int", nullable: true),
                    MetalQuantity = table.Column<int>(type: "int", nullable: false),
                    MetalloidID = table.Column<int>(type: "int", nullable: true),
                    MetalloidQuantity = table.Column<int>(type: "int", nullable: false),
                    NonMetalID = table.Column<int>(type: "int", nullable: true),
                    NonMetalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compound", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Compound_Metal_MetalID",
                        column: x => x.MetalID,
                        principalTable: "Metal",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Compound_Metalloid_MetalloidID",
                        column: x => x.MetalloidID,
                        principalTable: "Metalloid",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Compound_NonMetal_NonMetalID",
                        column: x => x.NonMetalID,
                        principalTable: "NonMetal",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compound_MetalID",
                table: "Compound",
                column: "MetalID");

            migrationBuilder.CreateIndex(
                name: "IX_Compound_MetalloidID",
                table: "Compound",
                column: "MetalloidID");

            migrationBuilder.CreateIndex(
                name: "IX_Compound_NonMetalID",
                table: "Compound",
                column: "NonMetalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compound");

            migrationBuilder.DropTable(
                name: "Metal");

            migrationBuilder.DropTable(
                name: "Metalloid");

            migrationBuilder.DropTable(
                name: "NonMetal");
        }
    }
}
