using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBank.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    ExchangeRate = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PosID = table.Column<int>(type: "INT", nullable: false),
                    PosName = table.Column<string>(type: "NVARCHAR (60)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<string>(type: "NVARCHAR (200)", nullable: false),
                    Requirements = table.Column<string>(type: "NVARCHAR (200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PosID);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    DepID = table.Column<int>(type: "INT", nullable: false),
                    DepName = table.Column<string>(type: "VARCHAR (60)", nullable: false),
                    MinDepTern = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    MinDepAmount = table.Column<int>(type: "INT", nullable: false),
                    AddCond = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    InterestRate = table.Column<double>(type: "FLOAT", nullable: false),
                    CurID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.DepID);
                    table.ForeignKey(
                        name: "FK_Deposit_Currency_CurID",
                        column: x => x.CurID,
                        principalTable: "Currency",
                        principalColumn: "CurID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmID = table.Column<int>(type: "INT", nullable: false),
                    Full_Name = table.Column<string>(type: "NVARCHAR (60)", nullable: false),
                    Adress = table.Column<string>(type: "NVARCHAR (100)", nullable: false),
                    Telephone = table.Column<string>(type: "NVARCHAR (11)", nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR (1)", nullable: false),
                    PosID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmID);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PosID",
                        column: x => x.PosID,
                        principalTable: "Position",
                        principalColumn: "PosID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositor",
                columns: table => new
                {
                    DepostorID = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR (60)", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    PhoneNum = table.Column<string>(type: "VARCHAR (11)", nullable: false),
                    PassData = table.Column<string>(type: "VARCHAR (20)", nullable: false),
                    DeposDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    RefundDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SummAm = table.Column<int>(type: "INT", nullable: false),
                    SummRef = table.Column<int>(type: "INT", nullable: false),
                    DepRafMark = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    EmID = table.Column<int>(type: "INT", nullable: false),
                    DepID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositor", x => x.DepostorID);
                    table.ForeignKey(
                        name: "FK_Depositor_Employee_EmID",
                        column: x => x.EmID,
                        principalTable: "Employee",
                        principalColumn: "EmID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_CurID",
                table: "Deposit",
                column: "CurID");

            migrationBuilder.CreateIndex(
                name: "IX_Depositor_EmID",
                table: "Depositor",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PosID",
                table: "Employee",
                column: "PosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Depositor");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
