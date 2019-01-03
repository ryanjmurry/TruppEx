using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TruppEx.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "LifeEventTypes",
                columns: table => new
                {
                    LifeEventTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeEventTypes", x => x.LifeEventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "LifeEvents",
                columns: table => new
                {
                    LifeEventID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(nullable: false),
                    LifeEventTypeID = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeEvents", x => x.LifeEventID);
                    table.ForeignKey(
                        name: "FK_LifeEvents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LifeEvents_LifeEventTypes_LifeEventTypeID",
                        column: x => x.LifeEventTypeID,
                        principalTable: "LifeEventTypes",
                        principalColumn: "LifeEventTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LifeEvents_EmployeeID",
                table: "LifeEvents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LifeEvents_LifeEventTypeID",
                table: "LifeEvents",
                column: "LifeEventTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LifeEvents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LifeEventTypes");
        }
    }
}
