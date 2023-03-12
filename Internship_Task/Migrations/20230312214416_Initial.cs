using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_Task.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Address", "DateOfStart", "Department", "Email", "FullName", "MonthlySalary", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Struma 13", new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "service", "adespinov@gmail.com", "Angel Despinov", 4023.52m, "+359882563" },
                    { 2, "Struma 12", new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "service", "vdespinova@gmail.com", "Vanina Despinova", 3023.52m, "+35988223563" },
                    { 3, "Petur Beron 13", new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "service", "tvideva@gmail.com", "Tania Videva", 4223.11m, "+359886572563" },
                    { 4, "Petur Beron 6", new DateTime(2002, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "service", "nvidev@gmail.com", "Nikolai Videv", 5013.22m, "+35988762563" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "ManagerId", "MonthlySalary", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "videvgeorge@gmail.com", "Georgi Nikolaev Videv", 1, 400.52m, "+359884550043" },
                    { 2, new DateTime(2002, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "hdespinova@gmail.com", "Hristina Angelova Despinova", 1, 432.52m, "+35923102309" },
                    { 3, new DateTime(2002, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "apavlov@gmail.com", "Angel Pavlov Pavlov", 2, 931.52m, "+359882321313" },
                    { 4, new DateTime(2002, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mcenova@gmail.com", "Mila Hristova Cenova", 2, 410.52m, "+35988485043" },
                    { 5, new DateTime(2002, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "mdimitrova@gmail.com", "Maria Dimitrova Dimitrova", 2, 231.52m, "+359877643" },
                    { 6, new DateTime(2003, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mjekova@gmail.com", "Magdalena Miroslavova Jekova", 3, 230.52m, "+35988786743" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "Description", "DueDate", "Title" },
                values: new object[,]
                {
                    { 1, 3, "something...", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 1" },
                    { 2, 2, "something...", new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 2" },
                    { 3, 4, "something...", new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 3" },
                    { 4, 2, "something...", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 4" },
                    { 5, 3, "something...", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 5" },
                    { 6, 2, "something...", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 6" },
                    { 7, 1, "something...", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 7" },
                    { 8, 1, "something...", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 8" },
                    { 9, 1, "something...", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 9" },
                    { 10, 5, "something...", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
