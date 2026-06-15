using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_records_attendance_records_AttendanceRecordId",
                table: "attendance_records");

            migrationBuilder.DropIndex(
                name: "IX_attendance_records_AttendanceRecordId",
                table: "attendance_records");

            migrationBuilder.DropColumn(
                name: "AttendanceRecordId",
                table: "attendance_records");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_records_attendance_records_AttendanceRecordId",
                table: "attendance_records",
                column: "AttendanceRecordId",
                principalTable: "attendance_records",
                principalColumn: "Id");
        }
    }
}
