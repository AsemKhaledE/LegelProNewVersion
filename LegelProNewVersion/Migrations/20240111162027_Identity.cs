using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LegelProNewVersion.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "MainDetails");

            migrationBuilder.EnsureSchema(
                name: "Login");

            migrationBuilder.EnsureSchema(
                name: "Main");

            migrationBuilder.CreateTable(
                name: "tbl_AdvancedSetting",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckedData = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AdvancedSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ApproveStatus",
                schema: "Security",
                columns: table => new
                {
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproveArabicName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ApproveEnglishName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ApproveStatus", x => x.ApproveStatusId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Bank",
                schema: "MainDetails",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoginStyle",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleNameArabic = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    StyleNameEnglish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    TextFont = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoginColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LoginBackground = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    IsMultiImage = table.Column<bool>(type: "bit", nullable: false),
                    TimeInterval = table.Column<int>(type: "int", nullable: false),
                    LoginPath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoginStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MainStyle",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleNameArabic = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    StyleNameEnglish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DashboardPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WelcomePageImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MainStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Pages",
                schema: "Security",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Areas",
                schema: "MainDetails",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_tbl_Areas_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Entities",
                schema: "MainDetails",
                columns: table => new
                {
                    EntitieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntitieArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntitieEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Entities", x => x.EntitieId);
                    table.ForeignKey(
                        name: "FK_tbl_Entities_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Job",
                schema: "MainDetails",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_tbl_Job_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Mailer",
                schema: "MainDetails",
                columns: table => new
                {
                    MailerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailerArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MailerEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Mailer", x => x.MailerId);
                    table.ForeignKey(
                        name: "FK_tbl_Mailer_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TheImportanceOfMail",
                schema: "MainDetails",
                columns: table => new
                {
                    TheImportanceOfMailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheImportanceOfMailArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TheImportanceOfMailEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TheImportanceOfMail", x => x.TheImportanceOfMailId);
                    table.ForeignKey(
                        name: "FK_tbl_TheImportanceOfMail_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TypeOfJob",
                schema: "MainDetails",
                columns: table => new
                {
                    TypeOfJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TypeOfJob", x => x.TypeOfJobId);
                    table.ForeignKey(
                        name: "FK_tbl_TypeOfJob_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoginStyleImages",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tbl_LoginStyleId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoginStyleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_LoginStyleImages_tbl_LoginStyle_tbl_LoginStyleId",
                        column: x => x.tbl_LoginStyleId,
                        principalSchema: "Login",
                        principalTable: "tbl_LoginStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SystemConfig",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveDirectoryEnable = table.Column<bool>(type: "bit", nullable: false),
                    ActiveDirectoryDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveDirectoryIbmLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveDirectoryIsAttachment = table.Column<bool>(type: "bit", maxLength: 75, nullable: false),
                    ActiveDirectoryIsIbmAttachment = table.Column<bool>(type: "bit", nullable: false),
                    ActiveDirectoryIsSendMail = table.Column<bool>(type: "bit", nullable: false),
                    ActiveDirectoryUserName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ActiveDirectoryPassword = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BankNameArabic = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    BankNameEnglish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    BankBranchNumber = table.Column<int>(type: "int", nullable: false),
                    BankLogoPath = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    BankImagePath = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    EnableMultiLanguage = table.Column<bool>(type: "bit", nullable: false),
                    EnableOTP = table.Column<bool>(type: "bit", nullable: false),
                    tbl_LoginStyleId = table.Column<int>(type: "int", nullable: false),
                    tbl_MainStyleId = table.Column<int>(type: "int", nullable: false),
                    NumberOfMaxCreateUser = table.Column<int>(type: "int", nullable: false),
                    NumberOfMaxUserLoginAtTime = table.Column<int>(type: "int", nullable: false),
                    WelcomeScreenImage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    WelcomeScreenTimeInterval = table.Column<int>(type: "int", nullable: false),
                    WelcomeScreenTextArabic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WelcomeScreenTextEnglish = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SystemConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_SystemConfig_tbl_LoginStyle_tbl_LoginStyleId",
                        column: x => x.tbl_LoginStyleId,
                        principalSchema: "Login",
                        principalTable: "tbl_LoginStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_SystemConfig_tbl_MainStyle_tbl_MainStyleId",
                        column: x => x.tbl_MainStyleId,
                        principalSchema: "Main",
                        principalTable: "tbl_MainStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Branch",
                schema: "MainDetails",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Branch", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_tbl_Branch_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Branch_tbl_Areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Client",
                schema: "MainDetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TheDeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_tbl_Client_tbl_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Client_tbl_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Department",
                schema: "MainDetails",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    IsSupDepartment = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tbl_Department_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Department_tbl_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SubDepartment",
                schema: "MainDetails",
                columns: table => new
                {
                    SubDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDepartmentArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubDepartmentEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SubDepartment", x => x.SubDepartmentId);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartment_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartment_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TypeOfMail",
                schema: "MainDetails",
                columns: table => new
                {
                    TypeOfMailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfMailArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfMailEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    tbl_TypeMail = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TypeOfMail", x => x.TypeOfMailId);
                    table.ForeignKey(
                        name: "FK_tbl_TypeOfMail_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Employee",
                schema: "Security",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeEnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproveStatusId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SubDepartmentId = table.Column<int>(type: "int", nullable: false),
                    tbl_JobId = table.Column<int>(type: "int", nullable: false),
                    TypeOfJobId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_ApproveStatus_ApproveStatusId",
                        column: x => x.ApproveStatusId,
                        principalSchema: "Security",
                        principalTable: "tbl_ApproveStatus",
                        principalColumn: "ApproveStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_Job_tbl_JobId",
                        column: x => x.tbl_JobId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_SubDepartment_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_SubDepartment",
                        principalColumn: "SubDepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_Employee_tbl_TypeOfJob_TypeOfJobId",
                        column: x => x.TypeOfJobId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_TypeOfJob",
                        principalColumn: "TypeOfJobId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SubDepartmentRole",
                schema: "Security",
                columns: table => new
                {
                    SubRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SubDepartmentId = table.Column<int>(type: "int", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    RoleNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdd = table.Column<bool>(type: "bit", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsDetails = table.Column<bool>(type: "bit", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsMaker = table.Column<bool>(type: "bit", nullable: false),
                    IsChecher = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SubDepartmentRole", x => x.SubRoleId);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartmentRole_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartmentRole_tbl_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "Security",
                        principalTable: "tbl_Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_SubDepartmentRole_tbl_SubDepartment_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_SubDepartment",
                        principalColumn: "SubDepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Security",
                        principalTable: "tbl_Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_RolePages",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RolePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RolePages_tbl_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "Security",
                        principalTable: "tbl_Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_RolePages_tbl_SubDepartmentRole_SubId",
                        column: x => x.SubId,
                        principalSchema: "Security",
                        principalTable: "tbl_SubDepartmentRole",
                        principalColumn: "SubRoleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserPages",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_UserPages_tbl_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "Security",
                        principalTable: "tbl_Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_UserPages_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "tbl_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRole",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsAdd = table.Column<bool>(type: "bit", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsDetails = table.Column<bool>(type: "bit", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsMaker = table.Column<bool>(type: "bit", nullable: false),
                    IsChecher = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SubDepartmentId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    tbl_SubDepartmentRoleSubRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Security",
                        principalTable: "tbl_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "Security",
                        principalTable: "tbl_Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_SubDepartmentRole_tbl_SubDepartmentRoleSubRoleId",
                        column: x => x.tbl_SubDepartmentRoleSubRoleId,
                        principalSchema: "Security",
                        principalTable: "tbl_SubDepartmentRole",
                        principalColumn: "SubRoleId");
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_SubDepartment_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalSchema: "MainDetails",
                        principalTable: "tbl_SubDepartment",
                        principalColumn: "SubDepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "tbl_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "tbl_AdvancedSetting",
                columns: new[] { "Id", "CheckedData" },
                values: new object[] { 1, false });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_ApproveStatus",
                columns: new[] { "ApproveStatusId", "ApproveArabicName", "ApproveBy", "ApproveDate", "ApproveEnglishName", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate" },
                values: new object[,]
                {
                    { 1, "قيد الإنتظار", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, "موافقة", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approve", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, "رفض", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denial", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_Bank",
                columns: new[] { "BankId", "ApproveBy", "ApproveDate", "BankName", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "البنك العربي الافريقي", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                schema: "Login",
                table: "tbl_LoginStyle",
                columns: new[] { "Id", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "IsMultiImage", "LastUpdateBy", "LastUpdateDate", "LoginBackground", "LoginColor", "LoginPath", "StyleNameArabic", "StyleNameEnglish", "TextColor", "TextFont", "TimeInterval" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "white", "black", "/LoginStyle/style1", "النمط الاول", "Style1", "White", "cursive", 10 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "white", "White", "/LoginStyle/style2", "النمط الثاني", "Style2", "black", "cursive", 10 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "white", "White", "/LoginStyle/style3", "النمط الثالث", "Style3", "black", "cursive", 10 }
                });

            migrationBuilder.InsertData(
                schema: "Main",
                table: "tbl_MainStyle",
                columns: new[] { "Id", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "DashboardPath", "DescriptionArabic", "DescriptionEnglish", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "StyleNameArabic", "StyleNameEnglish", "WelcomePageImagePath" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "_dashboard", "لوحة التحكم", "Dashboard", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "لوحة التحكم 1", "Dashboard 1", "/img/logoo.png" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_Pages",
                columns: new[] { "PageId", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "Name", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "system-configurations", "الاعدادات العامة للنظام الخاصة بالشركة ", "System Configs" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-branches", "الفروع", "Branches " },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-regions", "المناطق", "Regions " },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-jobs", "الوظائف", "Jobs" },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-entities", "الجهات", "Entities" },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-department", "الاقسسام الرئيسية", "Departments" },
                    { 7, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-sub-departments", "الاقسسام الفرعية", "Sub-Departments" },
                    { 8, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-the-importance-of-mail", "أهمية البريد", "The Importance Of Mail" },
                    { 9, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-types-of-mail", "نوع البريد", "Types Of Mail" },
                    { 10, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-manage-permissions", "ادارة الصلاحيات", "Manage Permissions" },
                    { 11, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-employee", "بيانات الموظفين", "Employee Data" },
                    { 12, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-type-of-job", "نوع الوظيفة", "Types Of Job" },
                    { 13, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-mailers", "جهات البريد", "Mailers" },
                    { 14, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "view-clients", "العملاء", "Clients " }
                });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_Areas",
                columns: new[] { "AreaId", "ApproveBy", "ApproveDate", "ApproveStatusId", "AreaArabicName", "AreaEnglishName", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "المنطقة", "Area", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_Job",
                columns: new[] { "JobId", "ApproveBy", "ApproveDate", "ApproveStatusId", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "JobArabicName", "JobEnglishName", "LastUpdateBy", "LastUpdateDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مهندس تقني", "Technical Engineer", null, null });

            migrationBuilder.InsertData(
                schema: "Login",
                table: "tbl_LoginStyleImages",
                columns: new[] { "Id", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "ImagePath", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "tbl_LoginStyleId" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img1 style 3.jpg", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 });

            migrationBuilder.InsertData(
                schema: "System",
                table: "tbl_SystemConfig",
                columns: new[] { "Id", "ActiveDirectoryDomain", "ActiveDirectoryEnable", "ActiveDirectoryIbmLink", "ActiveDirectoryIsAttachment", "ActiveDirectoryIsIbmAttachment", "ActiveDirectoryIsSendMail", "ActiveDirectoryPassword", "ActiveDirectoryUserName", "ApproveBy", "ApproveDate", "BankBranchNumber", "BankImagePath", "BankLogoPath", "BankNameArabic", "BankNameEnglish", "CreationBy", "CreationDate", "EnableMultiLanguage", "EnableOTP", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "NumberOfMaxCreateUser", "NumberOfMaxUserLoginAtTime", "WelcomeScreenImage", "WelcomeScreenTextArabic", "WelcomeScreenTextEnglish", "WelcomeScreenTimeInterval", "tbl_LoginStyleId", "tbl_MainStyleId" },
                values: new object[] { 1, "Active", true, "Active", true, true, true, "123", "Active@gmail.com", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "/img/BankImage.jpg", "/img/Banklogo.jpg", "بنك مصر", "bank misr", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 1, "/img/logoo.jpg", "مرحبا", "Welcome", 10, 3, 1 });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_TypeOfJob",
                columns: new[] { "TypeOfJobId", "ApproveBy", "ApproveDate", "ApproveStatusId", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "NameAr", "NameEn" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "مهندس", "Engineer" });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_Branch",
                columns: new[] { "BranchId", "ApproveBy", "ApproveDate", "ApproveStatusId", "AreaId", "BranchArabicName", "BranchEnglishName", "CreationBy", "CreationDate", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "الفرع الرئيسي", "Main Branch", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_Department",
                columns: new[] { "DepartmentId", "ApproveBy", "ApproveDate", "ApproveStatusId", "BranchId", "CreationBy", "CreationDate", "DepartmentArabicName", "DepartmentEnglishName", "IsDelete", "IsDeleteBy", "IsDeleteDate", "IsSupDepartment", "LastUpdateBy", "LastUpdateDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شركة EHM", "EHM", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الدعم الفني للنظام", "System Technical Support", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                columns: new[] { "SubDepartmentId", "ApproveBy", "ApproveDate", "ApproveStatusId", "CreationBy", "CreationDate", "DepartmentId", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "SubDepartmentArabicName", "SubDepartmentEnglishName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "EHMشركة", "EHM" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "منفذ النظام", "Maker" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "مصرح النظام", "Checher" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_Employee",
                columns: new[] { "EmployeeId", "Address", "ApproveBy", "ApproveDate", "ApproveStatusId", "BranchId", "CreationBy", "CreationDate", "DepartmentId", "EmployeeArabicName", "EmployeeEnglishName", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastUpdateBy", "LastUpdateDate", "PhoneNumber", "SubDepartmentId", "TypeOfJobId", "tbl_JobId" },
                values: new object[,]
                {
                    { 1, "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "شركة EHM", "EHM", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "", 1, 1, 1 },
                    { 2, "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "منفذ النظام", "Maker", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "", 2, 1, 1 },
                    { 3, "", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "مصرح النظام", "Checher", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "", 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_SubDepartmentRole",
                columns: new[] { "SubRoleId", "DepartmentId", "IsAdd", "IsChecher", "IsDelete", "IsDetails", "IsEdit", "IsMaker", "IsView", "PageId", "RoleNameAr", "RoleNameEn", "SubDepartmentId" },
                values: new object[,]
                {
                    { 1, 1, false, false, false, false, false, false, false, 1, "EHMشركة", "AdminEHM", 1 },
                    { 2, 2, true, false, true, true, true, true, true, 2, "", "", 2 },
                    { 3, 2, false, true, false, true, false, false, true, 2, "", "", 3 },
                    { 4, 2, true, false, true, true, true, true, true, 3, "", "", 2 },
                    { 5, 2, false, true, false, true, false, false, true, 3, "", "", 3 },
                    { 6, 2, true, false, true, true, true, true, true, 4, "", "", 2 },
                    { 7, 2, false, true, false, true, false, false, true, 4, "", "", 3 },
                    { 8, 2, true, false, true, true, true, true, true, 5, "", "", 2 },
                    { 9, 2, false, true, false, true, false, false, true, 5, "", "", 3 },
                    { 10, 2, true, false, true, true, true, true, true, 6, "", "", 2 },
                    { 11, 2, false, true, false, true, false, false, true, 6, "", "", 3 },
                    { 12, 2, true, false, true, true, true, true, true, 7, "", "", 2 },
                    { 13, 2, false, true, false, true, false, false, true, 7, "", "", 3 },
                    { 14, 2, true, false, true, true, true, true, true, 8, "", "", 2 },
                    { 15, 2, false, true, false, true, false, false, true, 8, "", "", 3 },
                    { 16, 2, true, false, true, true, true, true, true, 9, "", "", 2 },
                    { 17, 2, false, true, false, true, false, false, true, 9, "", "", 3 },
                    { 18, 2, true, false, true, true, true, true, true, 10, "", "", 2 },
                    { 19, 2, false, true, false, true, false, false, true, 10, "", "", 3 },
                    { 20, 2, true, false, true, true, true, true, true, 11, "", "", 2 },
                    { 21, 2, false, true, false, true, false, false, true, 11, "", "", 3 },
                    { 22, 2, true, false, true, true, true, true, true, 12, "", "", 2 },
                    { 23, 2, false, true, false, true, false, false, true, 12, "", "", 3 },
                    { 24, 2, true, false, true, true, true, true, true, 13, "", "", 2 },
                    { 25, 2, false, true, false, true, false, false, true, 13, "", "", 3 }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_Users",
                columns: new[] { "UserId", "ApproveBy", "ApproveDate", "CreationBy", "CreationDate", "Email", "EmployeeId", "IsActive", "IsDelete", "IsDeleteBy", "IsDeleteDate", "LastLoginDate", "LastUpdateBy", "LastUpdateDate", "Password", "UserEndDate", "UserName", "UserStartDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, false, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "P@ssword123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AdminEHM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, false, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "P@ssword123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maker", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, false, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "P@ssword123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Checher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "tbl_UserRole",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "IsAdd", "IsChecher", "IsDelete", "IsDetails", "IsEdit", "IsMaker", "IsView", "PageId", "SubDepartmentId", "UserId", "tbl_SubDepartmentRoleSubRoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, true, false, true, true, true, true, true, 1, 1, 1, null },
                    { 2, 2, 2, true, false, true, true, true, true, true, 2, 2, 2, null },
                    { 3, 2, 3, false, true, false, true, false, false, true, 2, 3, 3, null },
                    { 4, 2, 2, true, false, true, true, true, true, true, 3, 2, 2, null },
                    { 5, 2, 3, false, true, false, true, false, false, true, 3, 3, 3, null },
                    { 6, 2, 2, true, false, true, true, true, true, true, 4, 2, 2, null },
                    { 7, 2, 3, false, true, false, true, false, false, true, 4, 3, 3, null },
                    { 8, 2, 2, true, false, true, true, true, true, true, 5, 2, 2, null },
                    { 9, 2, 3, false, true, false, true, false, false, true, 5, 3, 3, null },
                    { 10, 2, 2, true, false, true, true, true, true, true, 6, 2, 2, null },
                    { 11, 2, 3, false, true, false, true, false, false, true, 6, 3, 3, null },
                    { 12, 2, 2, true, false, true, true, true, true, true, 7, 2, 2, null },
                    { 13, 2, 3, false, true, false, true, false, false, true, 7, 3, 3, null },
                    { 14, 2, 2, true, false, true, true, true, true, true, 8, 2, 2, null },
                    { 15, 2, 3, false, true, false, true, false, false, true, 8, 3, 3, null },
                    { 16, 2, 2, true, false, true, true, true, true, true, 9, 2, 2, null },
                    { 17, 2, 3, false, true, false, true, false, false, true, 9, 3, 3, null },
                    { 18, 2, 2, true, false, true, true, true, true, true, 10, 2, 2, null },
                    { 19, 2, 3, false, true, false, true, false, false, true, 10, 3, 3, null },
                    { 20, 2, 2, true, false, true, true, true, true, true, 11, 2, 2, null },
                    { 21, 2, 3, false, true, false, true, false, false, true, 11, 3, 3, null },
                    { 22, 2, 2, true, false, true, true, true, true, true, 12, 2, 2, null },
                    { 23, 2, 3, false, true, false, true, false, false, true, 12, 3, 3, null },
                    { 24, 2, 2, true, false, true, true, true, true, true, 13, 2, 2, null },
                    { 25, 2, 3, false, true, false, true, false, false, true, 13, 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Areas_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Areas",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Branch_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Branch",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Branch_AreaId",
                schema: "MainDetails",
                table: "tbl_Branch",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Client_BankId",
                schema: "MainDetails",
                table: "tbl_Client",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Client_BranchId",
                schema: "MainDetails",
                table: "tbl_Client",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Department_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Department",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Department_BranchId",
                schema: "MainDetails",
                table: "tbl_Department",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_ApproveStatusId",
                schema: "Security",
                table: "tbl_Employee",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_BranchId",
                schema: "Security",
                table: "tbl_Employee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_DepartmentId",
                schema: "Security",
                table: "tbl_Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_SubDepartmentId",
                schema: "Security",
                table: "tbl_Employee",
                column: "SubDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_tbl_JobId",
                schema: "Security",
                table: "tbl_Employee",
                column: "tbl_JobId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_TypeOfJobId",
                schema: "Security",
                table: "tbl_Employee",
                column: "TypeOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Entities_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Entities",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Job_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Job",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoginStyleImages_tbl_LoginStyleId",
                schema: "Login",
                table: "tbl_LoginStyleImages",
                column: "tbl_LoginStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Mailer_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_Mailer",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RolePages_PageId",
                schema: "Security",
                table: "tbl_RolePages",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RolePages_SubId",
                schema: "Security",
                table: "tbl_RolePages",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartment_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartment_DepartmentId",
                schema: "MainDetails",
                table: "tbl_SubDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartmentRole_DepartmentId",
                schema: "Security",
                table: "tbl_SubDepartmentRole",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartmentRole_PageId",
                schema: "Security",
                table: "tbl_SubDepartmentRole",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubDepartmentRole_SubDepartmentId",
                schema: "Security",
                table: "tbl_SubDepartmentRole",
                column: "SubDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SystemConfig_tbl_LoginStyleId",
                schema: "System",
                table: "tbl_SystemConfig",
                column: "tbl_LoginStyleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SystemConfig_tbl_MainStyleId",
                schema: "System",
                table: "tbl_SystemConfig",
                column: "tbl_MainStyleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TheImportanceOfMail_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_TheImportanceOfMail",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TypeOfJob_ApproveStatusId",
                schema: "MainDetails",
                table: "tbl_TypeOfJob",
                column: "ApproveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TypeOfMail_DepartmentId",
                schema: "MainDetails",
                table: "tbl_TypeOfMail",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserPages_PageId",
                schema: "Security",
                table: "tbl_UserPages",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserPages_UserId",
                schema: "Security",
                table: "tbl_UserPages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_DepartmentId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_EmployeeId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_PageId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_SubDepartmentId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "SubDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_tbl_SubDepartmentRoleSubRoleId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "tbl_SubDepartmentRoleSubRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_UserId",
                schema: "Security",
                table: "tbl_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_EmployeeId",
                schema: "Security",
                table: "tbl_Users",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AdvancedSetting",
                schema: "System");

            migrationBuilder.DropTable(
                name: "tbl_Client",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_Entities",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_LoginStyleImages",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "tbl_Mailer",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_RolePages",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_SystemConfig",
                schema: "System");

            migrationBuilder.DropTable(
                name: "tbl_TheImportanceOfMail",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_TypeOfMail",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_UserPages",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_UserRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_Bank",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_LoginStyle",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "tbl_MainStyle",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "tbl_SubDepartmentRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_Pages",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_Employee",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "tbl_Job",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_SubDepartment",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_TypeOfJob",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_Department",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_Branch",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_Areas",
                schema: "MainDetails");

            migrationBuilder.DropTable(
                name: "tbl_ApproveStatus",
                schema: "Security");
        }
    }
}
