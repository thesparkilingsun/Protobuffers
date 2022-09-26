using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProtoBuffers.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fetch = table.Column<bool>(type: "bit", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderSourceDestinaton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSourceDestinaton", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipToId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderData_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderSourceDestinatonId = table.Column<int>(type: "int", nullable: false),
                    OrderDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSchema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSchema_OrderData_OrderDataId",
                        column: x => x.OrderDataId,
                        principalTable: "OrderData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSchema_OrderSourceDestinaton_OrderSourceDestinatonId",
                        column: x => x.OrderSourceDestinatonId,
                        principalTable: "OrderSourceDestinaton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "Code", "Fetch", "Path" },
                values: new object[,]
                {
                    { 6, "101", false, "La-CA" },
                    { 15, "111", true, "CA-LA" }
                });

            migrationBuilder.InsertData(
                table: "OrderSourceDestinaton",
                columns: new[] { "Id", "DestinationId", "DestinationName", "SourceId", "SourceName" },
                values: new object[,]
                {
                    { 3, 98, "IND", 88, "BHA" },
                    { 12, 99, "ND", 89, "BA" }
                });

            migrationBuilder.InsertData(
                table: "Shipment",
                columns: new[] { "Id", "Address", "Carrier", "CarrierId", "Code", "CompanyName", "IsoCountry", "ItemsId", "Name", "PostalCode", "ShipToId", "Town" },
                values: new object[,]
                {
                    { 4, "Hindus Force Fortress", "DeltaD", 412, "368M", "Hindu Force", "IN", 0, "Netaji", "61282", 214, "Bharat" },
                    { 13, "Hindus Forc", "DeltD", 412, "MM368", "Hindu orce", "NI", 0, "Neta", "1282", 100, "Bhar" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ComponentId", "ShipmentId", "Sku" },
                values: new object[,]
                {
                    { 5, 6, null, "LA1" },
                    { 14, 15, null, "LA3" }
                });

            migrationBuilder.InsertData(
                table: "OrderData",
                columns: new[] { "Id", "ShipmentId" },
                values: new object[,]
                {
                    { 2, 4 },
                    { 11, 13 }
                });

            migrationBuilder.InsertData(
                table: "OrderSchema",
                columns: new[] { "Id", "OrderDataId", "OrderSourceDestinatonId" },
                values: new object[] { 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "OrderSchema",
                columns: new[] { "Id", "OrderDataId", "OrderSourceDestinatonId" },
                values: new object[] { 10, 11, 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ComponentId",
                table: "Items",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShipmentId",
                table: "Items",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderData_ShipmentId",
                table: "OrderData",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSchema_OrderDataId",
                table: "OrderSchema",
                column: "OrderDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSchema_OrderSourceDestinatonId",
                table: "OrderSchema",
                column: "OrderSourceDestinatonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OrderSchema");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "OrderData");

            migrationBuilder.DropTable(
                name: "OrderSourceDestinaton");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
