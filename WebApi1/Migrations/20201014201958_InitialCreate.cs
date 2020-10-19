using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatronModels",
                columns: table => new
                {
                    credentialID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronModels", x => x.credentialID);
                });

            migrationBuilder.CreateTable(
                name: "SocioModels",
                columns: table => new
                {
                    credentialID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioModels", x => x.credentialID);
                });

            migrationBuilder.CreateTable(
                name: "BarcoModels",
                columns: table => new
                {
                    boatID = table.Column<string>(type: "varchar(13)", nullable: false),
                    boatName = table.Column<string>(type: "varchar(15)", nullable: true),
                    boatFee = table.Column<string>(type: "varchar(13)", nullable: false),
                    mooringNumber = table.Column<string>(type: "varchar(13)", nullable: true),
                    credentialPatnerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcoModels", x => x.boatID);
                    table.ForeignKey(
                        name: "FK_BarcoModels_SocioModels_credentialPatnerID",
                        column: x => x.credentialPatnerID,
                        principalTable: "SocioModels",
                        principalColumn: "credentialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "outputDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "varchar(20)", nullable: false),
                    userName = table.Column<string>(type: "varchar(100)", nullable: false),
                    typeUser = table.Column<string>(type: "varchar(20)", nullable: false),
                    boatName = table.Column<string>(type: "varchar(100)", nullable: false),
                    boatID = table.Column<string>(type: "varchar(13)", nullable: false),
                    destiny = table.Column<string>(type: "varchar(100)", nullable: false),
                    fecha = table.Column<string>(type: "varchar(10)", nullable: false),
                    hora = table.Column<string>(type: "varchar(10)", nullable: false),
                    cuota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outputDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_outputDetails_BarcoModels_boatID",
                        column: x => x.boatID,
                        principalTable: "BarcoModels",
                        principalColumn: "boatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarcoModels_credentialPatnerID",
                table: "BarcoModels",
                column: "credentialPatnerID");

            migrationBuilder.CreateIndex(
                name: "IX_outputDetails_boatID",
                table: "outputDetails",
                column: "boatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outputDetails");

            migrationBuilder.DropTable(
                name: "PatronModels");

            migrationBuilder.DropTable(
                name: "BarcoModels");

            migrationBuilder.DropTable(
                name: "SocioModels");
        }
    }
}
