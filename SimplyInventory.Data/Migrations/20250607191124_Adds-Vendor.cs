using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddsVendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TermsId",
                table: "Vendor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsRef_FullName",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsRef_ListID",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorAddress_Addr1",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorAddress_Addr2",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorAddress_Addr3",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorAddress_Addr4",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorAddress_Addr5",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSync = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ListID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DiscountPct = table.Column<float>(type: "real", nullable: true),
                    TermsType = table.Column<int>(type: "int", nullable: false),
                    DayOfMonthDue = table.Column<int>(type: "int", nullable: true),
                    DueNextMonthDays = table.Column<int>(type: "int", nullable: true),
                    DiscountDayOfMonth = table.Column<int>(type: "int", nullable: true),
                    StdDueDays = table.Column<int>(type: "int", nullable: true),
                    StdDiscountDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_TermsId",
                table: "Vendor",
                column: "TermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Terms_TermsId",
                table: "Vendor",
                column: "TermsId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Terms_TermsId",
                table: "Vendor");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_TermsId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "TermsId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "TermsRef_FullName",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "TermsRef_ListID",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorAddress_Addr1",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorAddress_Addr2",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorAddress_Addr3",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorAddress_Addr4",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorAddress_Addr5",
                table: "Vendor");
        }
    }
}
