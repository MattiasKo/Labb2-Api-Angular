using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_Api_Angular.Migrations
{
    public partial class getid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { new Guid("2d4f9bbc-358b-49da-8bc4-43923e9147d6"), "SystemUtveckling" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Human resources" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"), "Teknik" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Adress", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { new Guid("1f9e4b0c-05bc-45b9-b36e-c1daeb9034a9"), "Halland", new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"), "hotmail.com", "Daniel", "Male", "osrkarsson", "5458522", 13500m },
                    { new Guid("42531374-5ebd-4e0f-9a8c-6f779224c592"), "Umeå", new Guid("2d4f9bbc-358b-49da-8bc4-43923e9147d6"), "atelje.com", "Anna", "Female", "Myberg", "04578521", 36500m },
                    { new Guid("4d4b72c7-2b8c-405c-baad-b1c26cd946d7"), "Långatan", new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"), "Häftigmail.com", "Mattias", "Male", "Jonsson", "0705454560", 11500m },
                    { new Guid("b2fef0c9-5736-40d6-a718-41d30f9406ca"), "Göteborg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "gmail.com", "Edwin", "Male", "Nocco", "05485036", 35400m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
