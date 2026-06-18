using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AttendanceRecordId",
                table: "attendance_records",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_attendance_records_AttendanceRecordId",
                table: "attendance_records",
                column: "AttendanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_records_WorkTypeId",
                table: "attendance_records",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_records_attendance_records_AttendanceRecordId",
                table: "attendance_records",
                column: "AttendanceRecordId",
                principalTable: "attendance_records",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_records_work_types_WorkTypeId",
                table: "attendance_records",
                column: "WorkTypeId",
                principalTable: "work_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_records_attendance_records_AttendanceRecordId",
                table: "attendance_records");

            migrationBuilder.DropForeignKey(
                name: "FK_attendance_records_work_types_WorkTypeId",
                table: "attendance_records");

            migrationBuilder.DropIndex(
                name: "IX_attendance_records_AttendanceRecordId",
                table: "attendance_records");

            migrationBuilder.DropIndex(
                name: "IX_attendance_records_WorkTypeId",
                table: "attendance_records");

            migrationBuilder.DropColumn(
                name: "AttendanceRecordId",
                table: "attendance_records");
        }
    }
}
