using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    IconPath = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__737D32F95032DA9A", x => x.LocationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attribut__C18929EABA5C8DE7", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK__Attribute__Locat__29572725",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "LocationTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA497D0DBDC5C", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK__Locations__Locat__267ABA7A",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "LocationTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__74BC79CEA081B53A", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK__Reviews__Locatio__2C3393D0",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_LocationTypeId",
                table: "Attributes",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeId",
                table: "Locations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_LocationId",
                table: "Reviews",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LocationTypes");
        }
    }
}
