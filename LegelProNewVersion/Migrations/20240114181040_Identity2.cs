using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LegelProNewVersion.Migrations
{
    /// <inheritdoc />
    public partial class Identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_TypeOfJob",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_TheImportanceOfMail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Mailer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Entities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "Security",
                table: "tbl_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Branch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Areas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_Areas",
                keyColumn: "AreaId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_Branch",
                keyColumn: "BranchId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_Department",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_Department",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "tbl_Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "tbl_Employee",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "tbl_Employee",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_Job",
                keyColumn: "JobId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_Pages",
                columns: new[] { "PageId", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "Name", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 15, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "sub-Roles", "صلاحيات الادارات الفرعية", "Sub-Department Roles" },
                    { 16, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "emlpoyee-Roles", "صلاحيات الموظفين", "Emlpoyee Roles" }
                });

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                keyColumn: "SubDepartmentId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                keyColumn: "SubDepartmentId",
                keyValue: 2,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                keyColumn: "SubDepartmentId",
                keyValue: 3,
                column: "ReasonForRejection",
                value: null);

            migrationBuilder.UpdateData(
                schema: "MainDetails",
                table: "tbl_TypeOfJob",
                keyColumn: "TypeOfJobId",
                keyValue: 1,
                column: "ReasonForRejection",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Security",
                table: "tbl_Pages",
                keyColumn: "PageId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Security",
                table: "tbl_Pages",
                keyColumn: "PageId",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_TypeOfJob");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_TheImportanceOfMail");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_SubDepartment");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Mailer");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Job");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Entities");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "Security",
                table: "tbl_Employee");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Department");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Branch");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                schema: "MainDetails",
                table: "tbl_Areas");
        }
    }
}
