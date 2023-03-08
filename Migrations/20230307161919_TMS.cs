using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS1.Migrations
{
    /// <inheritdoc />
    public partial class TMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteInfo",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stop1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stop2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteInfo", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    stop1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stop2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VehicleInfo",
                columns: table => new
                {
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleCapacity = table.Column<int>(type: "int", nullable: false),
                    SeatAvailablity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInfo", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfo", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_RouteInfo_RouteId",
                        column: x => x.RouteId,
                        principalTable: "RouteInfo",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_VehicleInfo_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleInfo",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Allocate",
                columns: table => new
                {
                    AllocatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocate", x => x.AllocatId);
                    table.ForeignKey(
                        name: "FK_Allocate_EmployeeInfo_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Allocate_RouteInfo_RouteId",
                        column: x => x.RouteId,
                        principalTable: "RouteInfo",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Allocate_VehicleInfo_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleInfo",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocate_EmployeeId",
                table: "Allocate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocate_RouteId",
                table: "Allocate",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocate_VehicleId",
                table: "Allocate",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_RouteId",
                table: "EmployeeInfo",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_VehicleId",
                table: "EmployeeInfo",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocate");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "EmployeeInfo");

            migrationBuilder.DropTable(
                name: "RouteInfo");

            migrationBuilder.DropTable(
                name: "VehicleInfo");
        }
    }
}
