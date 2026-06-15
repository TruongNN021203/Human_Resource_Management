using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_records_work_types_EmployeeId",
                table: "attendance_records");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_departments_ParentId1",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_ParentId1",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "ParentId1",
                table: "departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId1",
                table: "departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_ParentId1",
                table: "departments",
                column: "ParentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_records_work_types_EmployeeId",
                table: "attendance_records",
                column: "EmployeeId",
                principalTable: "work_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_departments_ParentId1",
                table: "departments",
                column: "ParentId1",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
