using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCarriers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3213E83F13F8544B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__3213E83F1153567F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vat_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    contact = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vendor__3213E83FFA892102", x => x.id);
                    table.ForeignKey(
                        name: "FK__Vendor__location__43D61337",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    miti = table.Column<DateOnly>(type: "date", nullable: false),
                    invoice_no = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Invoice__3213E83F5F1A4E68", x => x.id);
                    table.ForeignKey(
                        name: "FK__Invoice__categor__498EEC8D",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Invoice__locatio__489AC854",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Invoice__vendor___47A6A41B",
                        column: x => x.vendor_id,
                        principalTable: "Vendor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    rate = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    taxable_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    vat_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceI__3213E83FE0FF9FBE", x => x.id);
                    table.ForeignKey(
                        name: "FK__InvoiceIt__categ__4D5F7D71",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__InvoiceIt__invoi__4C6B5938",
                        column: x => x.invoice_id,
                        principalTable: "Invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Category__72E12F1BFEAB4084",
                table: "Category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_category_id",
                table: "Invoice",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_location_id",
                table: "Invoice",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_vendor_id",
                table: "Invoice",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Invoice__F58CA1E2FF83E40B",
                table: "Invoice",
                column: "invoice_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_category_id",
                table: "InvoiceItems",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_invoice_id",
                table: "InvoiceItems",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Location__72E12F1B5F46E249",
                table: "Location",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_location_id",
                table: "Vendor",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Vendor__B444FCAA6FAFD8C3",
                table: "Vendor",
                column: "vat_no",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
