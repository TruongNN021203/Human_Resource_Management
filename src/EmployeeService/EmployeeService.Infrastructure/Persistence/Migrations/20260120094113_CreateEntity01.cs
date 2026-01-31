using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntity01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "employee_details");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "employee_details");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "employee_details");

            migrationBuilder.CreateTable(
                name: "allowances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allowances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_allowances_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attendance_records",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance_records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attendance_records_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DepartmentName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departments_departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "education_levels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EducationLevelName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IssuedPlace = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    RegisteredHospital = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_insurances_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "labor_contracts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ContractNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    SalaryCoefficient = table.Column<float>(type: "real", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labor_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labor_contracts_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rewards_disciplinary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DecisionNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rewards_disciplinary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rewards_disciplinary_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salary_grades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BaseSalary = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "work_types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Coefficient = table.Column<float>(type: "real", nullable: false),
                    PublicId = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_EducationLevelId",
                table: "employees",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_allowances_EmployeeId",
                table: "allowances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_allowances_PublicId",
                table: "allowances",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attendance_records_EmployeeId",
                table: "attendance_records",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_records_PublicId",
                table: "attendance_records",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_Code",
                table: "departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_ParentId",
                table: "departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_PublicId",
                table: "departments",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_education_levels_PublicId",
                table: "education_levels",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_insurances_EmployeeId",
                table: "insurances",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_insurances_PublicId",
                table: "insurances",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_labor_contracts_ContractNumber",
                table: "labor_contracts",
                column: "ContractNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_labor_contracts_EmployeeId",
                table: "labor_contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_labor_contracts_PublicId",
                table: "labor_contracts",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rewards_disciplinary_EmployeeId",
                table: "rewards_disciplinary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_rewards_disciplinary_PublicId",
                table: "rewards_disciplinary",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_salary_grades_Code",
                table: "salary_grades",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_salary_grades_PublicId",
                table: "salary_grades",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_types_Name",
                table: "work_types",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_types_PublicId",
                table: "work_types",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_education_levels_EducationLevelId",
                table: "employees",
                column: "EducationLevelId",
                principalTable: "education_levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_education_levels_EducationLevelId",
                table: "employees");

            migrationBuilder.DropTable(
                name: "allowances");

            migrationBuilder.DropTable(
                name: "attendance_records");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "education_levels");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "labor_contracts");

            migrationBuilder.DropTable(
                name: "rewards_disciplinary");

            migrationBuilder.DropTable(
                name: "salary_grades");

            migrationBuilder.DropTable(
                name: "work_types");

            migrationBuilder.DropIndex(
                name: "IX_employees_EducationLevelId",
                table: "employees");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "employee_details",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "employee_details",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "employee_details",
                type: "text",
                nullable: true);
        }
    }
}
