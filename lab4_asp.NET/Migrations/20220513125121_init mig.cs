using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab4_asp.NET.Migrations
{
    public partial class initmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    IsBorrowed = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBooks",
                columns: table => new
                {
                    CustomerBookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    EndLoanDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBooks", x => x.CustomerBookId);
                    table.ForeignKey(
                        name: "FK_CustomerBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerBooks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Description", "ImageUrl", "IsBorrowed", "Title" },
                values: new object[,]
                {
                    { 1, "Fantasy om en grupp med personer som ska förstöra en ring", "\\images\\lotr.jpg", true, "Lord of the rings" },
                    { 2, "Biografi om en person som vill ha hjälp", "\\images\\hkohm.jfif", false, "Hej kom och hjälp mig!" },
                    { 3, "En grupp med superhjätar som ska försvara världen", "\\images\\avengers.jfif", true, "Avengers" },
                    { 4, "Superpippi", "\\images\\pippi.jfif", true, "Pippi Långstrump" },
                    { 5, "Verklighetsbaserad bok om en unge som lär sig magi", "\\images\\harryp.jfif", true, "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Storgatan 11, 89139 Övik", "Robin", "0705837487837" },
                    { 2, "Björkgatan 400, 90326 Umeå", "Peter", "09087238173" },
                    { 3, "Storgatan 11, 89139 Övik", "Maja", "0709348492834" },
                    { 4, "Hållgatan 1, 891340 Övik", "Petra", "070565675" },
                    { 5, "Gatan 3, 89111 Övik", "Sandra", "0705469456" },
                    { 6, "Storgatan 10, 90333 Umeå", "Håkan", "090123001239" },
                    { 7, "Storgatan 1, 89138 Övik", "Mendela", "07056045964" }
                });

            migrationBuilder.InsertData(
                table: "CustomerBooks",
                columns: new[] { "CustomerBookId", "BookId", "CustomerId", "EndLoanDate", "LoanDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 3, 1, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, 2, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 4, 2, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 5, 2, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 5, 3, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 5, 4, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 1, 5, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 4, 6, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 1, 7, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 5, 7, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooks_BookId",
                table: "CustomerBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooks_CustomerId",
                table: "CustomerBooks",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
