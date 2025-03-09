using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class gun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ProjectManagerId",
                table: "Project",
                newName: "EmployeeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                newName: "IX_Project_EmployeeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_EmployeeEntityId",
                table: "Project",
                column: "EmployeeEntityId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_EmployeeEntityId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "EmployeeEntityId",
                table: "Project",
                newName: "ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_EmployeeEntityId",
                table: "Project",
                newName: "IX_Project_ProjectManagerId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
