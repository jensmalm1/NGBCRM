using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NGB.Data.Migrations
{
    public partial class contactlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Customer",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FullContent = table.Column<string>(nullable: true),
                    SummaryContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEvent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactEvent_CustomerId",
                table: "ContactEvent",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactEvent");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Customer",
                newName: "Surname");
        }
    }
}
