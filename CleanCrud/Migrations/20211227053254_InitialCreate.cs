using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCrud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    PerformanceRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssuePatient",
                columns: table => new
                {
                    IssuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuePatient", x => new { x.IssuesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_IssuePatient_Issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuePatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specialization" },
                values: new object[,]
                {
                    { new Guid("2f059a80-63ad-4482-b95d-0891071977dd"), "Yasmeen", 92, 80000m, "Pediatrics" },
                    { new Guid("55dba7b8-b6f6-45e8-9169-474202fc919d"), "Khalid", 91, 97000m, "Radiology" },
                    { new Guid("6379bb0a-c89f-4fd6-82c9-4df0c011a9f4"), "Muahmmed", 95, 50000m, "Cardiology" },
                    { new Guid("6f9eeb2f-03e2-4532-9012-e89293450733"), "Maha", 99, 100000m, "Neurosurgery" },
                    { new Guid("8c821f20-f791-4a84-86d5-a0a4c2611cf0"), "Ahmed", 96, 70000m, "Surgery" },
                    { new Guid("dea6b27e-1b75-452b-ae3b-0577b81e5c43"), "Esam", 92, 77000m, "Obstetrics" },
                    { new Guid("e0556d41-c189-4779-b96f-3971a34d1ba4"), "Salma", 97, 85000m, "Pathology" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43e9bce9-cc30-4cc7-8c12-3271baa25bc3"), "Cold" },
                    { new Guid("e30c5a30-f25a-4ec8-a970-4cf50fd9d551"), "Stress" },
                    { new Guid("fd0f093e-b170-48da-9d6a-d733d77a8ac9"), "Headache" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14d1eeb9-edb5-41f3-a12a-8120e3d291fc"), "James" },
                    { new Guid("a1b70424-53e3-4370-ae7d-f5c63263d81f"), "John" },
                    { new Guid("b6f8f164-9915-4f74-9817-e1169d4272ac"), "Anderson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuePatient_PatientsId",
                table: "IssuePatient",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "IssuePatient");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
