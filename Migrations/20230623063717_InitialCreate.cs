using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenORG.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    ContinentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Countries = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ContinentID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    Subunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubunitValue = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentStatus",
                columns: table => new
                {
                    EnrollmentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatus", x => x.EnrollmentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    FileTypesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.FileTypesID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "LearningProgramStatus",
                columns: table => new
                {
                    LearningProgramStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgramStatus", x => x.LearningProgramStatusID);
                });

            migrationBuilder.CreateTable(
                name: "LearningProgramType",
                columns: table => new
                {
                    LearningProgramTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgramType", x => x.LearningProgramTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.PaymentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.SpecializationID);
                });

            migrationBuilder.CreateTable(
                name: "Timezone",
                columns: table => new
                {
                    TimezoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UTCOffset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSTOffset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSTStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DSTEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezone", x => x.TimezoneID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    UserImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypesID = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.UserImageID);
                    table.ForeignKey(
                        name: "FK_UserImage_FileTypes_FileTypesID",
                        column: x => x.FileTypesID,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypesID");
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaProfilesInstructor",
                columns: table => new
                {
                    SocialMediaProfilesInstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaProfilesInstructor", x => x.SocialMediaProfilesInstructorID);
                    table.ForeignKey(
                        name: "FK_SocialMediaProfilesInstructor_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinentID = table.Column<int>(type: "int", nullable: true),
                    CurrencyID = table.Column<int>(type: "int", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Continent_ContinentID",
                        column: x => x.ContinentID,
                        principalTable: "Continent",
                        principalColumn: "ContinentID");
                    table.ForeignKey(
                        name: "FK_Country_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "CurrencyID");
                    table.ForeignKey(
                        name: "FK_Country_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID");
                });

            migrationBuilder.CreateTable(
                name: "InstructorSpecialization",
                columns: table => new
                {
                    InstructorSpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    SpecializationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSpecialization", x => x.InstructorSpecializationID);
                    table.ForeignKey(
                        name: "FK_InstructorSpecialization_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_InstructorSpecialization_Specialization_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsID);
                    table.ForeignKey(
                        name: "FK_Skills_Specialization_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTimezone",
                columns: table => new
                {
                    CountryTimezoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    TimezoneID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimezone", x => x.CountryTimezoneID);
                    table.ForeignKey(
                        name: "FK_CountryTimezone_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTimezone_Timezone_TimezoneID",
                        column: x => x.TimezoneID,
                        principalTable: "Timezone",
                        principalColumn: "TimezoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                    table.ForeignKey(
                        name: "FK_Province_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSkills",
                columns: table => new
                {
                    InstructorSkillsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSkills", x => x.InstructorSkillsID);
                    table.ForeignKey(
                        name: "FK_InstructorSkills_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_InstructorSkills_Skills_SkillsID",
                        column: x => x.SkillsID,
                        principalTable: "Skills",
                        principalColumn: "SkillsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetID);
                    table.ForeignKey(
                        name: "FK_Street_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: true),
                    StreetID = table.Column<int>(type: "int", nullable: false),
                    UserImageID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Street_StreetID",
                        column: x => x.StreetID,
                        principalTable: "Street",
                        principalColumn: "StreetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserImage_UserImageID",
                        column: x => x.UserImageID,
                        principalTable: "UserImage",
                        principalColumn: "UserImageID");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Location_Street_StreetID",
                        column: x => x.StreetID,
                        principalTable: "Street",
                        principalColumn: "StreetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StreetID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantID);
                    table.ForeignKey(
                        name: "FK_Participant_Street_StreetID",
                        column: x => x.StreetID,
                        principalTable: "Street",
                        principalColumn: "StreetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AvailabilityEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StreetID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerID);
                    table.ForeignKey(
                        name: "FK_Volunteer_Street_StreetID",
                        column: x => x.StreetID,
                        principalTable: "Street",
                        principalColumn: "StreetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningProgramDetails",
                columns: table => new
                {
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningProgramTypeID = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    EnrollmentLimit = table.Column<int>(type: "int", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Curriculum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionCertificate = table.Column<bool>(type: "bit", nullable: true),
                    LearningProgramStatusID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgramDetails", x => x.LearningProgramDetailsID);
                    table.ForeignKey(
                        name: "FK_LearningProgramDetails_LearningProgramStatus_LearningProgramStatusID",
                        column: x => x.LearningProgramStatusID,
                        principalTable: "LearningProgramStatus",
                        principalColumn: "LearningProgramStatusID");
                    table.ForeignKey(
                        name: "FK_LearningProgramDetails_LearningProgramType_LearningProgramTypeID",
                        column: x => x.LearningProgramTypeID,
                        principalTable: "LearningProgramType",
                        principalColumn: "LearningProgramTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningProgramDetails_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateTable(
                name: "Partnership",
                columns: table => new
                {
                    PartnershipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerOrganization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnershipStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartnershipEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnership", x => x.PartnershipID);
                    table.ForeignKey(
                        name: "FK_Partnership_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    SponsorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorshipStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SponsorshipEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.SponsorID);
                    table.ForeignKey(
                        name: "FK_Sponsor_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantSpecialization",
                columns: table => new
                {
                    ParticipantSpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantID = table.Column<int>(type: "int", nullable: true),
                    SpecializationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantSpecialization", x => x.ParticipantSpecializationID);
                    table.ForeignKey(
                        name: "FK_ParticipantSpecialization_Participant_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Participant",
                        principalColumn: "ParticipantID");
                    table.ForeignKey(
                        name: "FK_ParticipantSpecialization_Specialization_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerSkills",
                columns: table => new
                {
                    VolunteerSkillsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsID = table.Column<int>(type: "int", nullable: false),
                    VolunteerID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerSkills", x => x.VolunteerSkillsID);
                    table.ForeignKey(
                        name: "FK_VolunteerSkills_Skills_SkillsID",
                        column: x => x.SkillsID,
                        principalTable: "Skills",
                        principalColumn: "SkillsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerSkills_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "VolunteerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: true),
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentStatusID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    PaymentStatusID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentsID);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentStatus_EnrollmentStatusID",
                        column: x => x.EnrollmentStatusID,
                        principalTable: "EnrollmentStatus",
                        principalColumn: "EnrollmentStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_LearningProgramDetails_LearningProgramDetailsID",
                        column: x => x.LearningProgramDetailsID,
                        principalTable: "LearningProgramDetails",
                        principalColumn: "LearningProgramDetailsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Participant_ID",
                        column: x => x.ID,
                        principalTable: "Participant",
                        principalColumn: "ParticipantID");
                    table.ForeignKey(
                        name: "FK_Enrollments_PaymentStatus_PaymentStatusID",
                        column: x => x.PaymentStatusID,
                        principalTable: "PaymentStatus",
                        principalColumn: "PaymentStatusID");
                });

            migrationBuilder.CreateTable(
                name: "InstructorLearningProgram",
                columns: table => new
                {
                    InstructorLearningProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorLearningProgram", x => x.InstructorLearningProgramID);
                    table.ForeignKey(
                        name: "FK_InstructorLearningProgram_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_InstructorLearningProgram_LearningProgramDetails_LearningProgramDetailsID",
                        column: x => x.LearningProgramDetailsID,
                        principalTable: "LearningProgramDetails",
                        principalColumn: "LearningProgramDetailsID");
                });

            migrationBuilder.CreateTable(
                name: "LearningProgramSpecialization",
                columns: table => new
                {
                    LearningProgramSpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: false),
                    SpecializationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgramSpecialization", x => x.LearningProgramSpecializationID);
                    table.ForeignKey(
                        name: "FK_LearningProgramSpecialization_LearningProgramDetails_LearningProgramDetailsID",
                        column: x => x.LearningProgramDetailsID,
                        principalTable: "LearningProgramDetails",
                        principalColumn: "LearningProgramDetailsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningProgramSpecialization_Specialization_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioMedia",
                columns: table => new
                {
                    PortfolioMediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypesID = table.Column<int>(type: "int", nullable: true),
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioMedia", x => x.PortfolioMediaID);
                    table.ForeignKey(
                        name: "FK_PortfolioMedia_FileTypes_FileTypesID",
                        column: x => x.FileTypesID,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypesID");
                    table.ForeignKey(
                        name: "FK_PortfolioMedia_LearningProgramDetails_LearningProgramDetailsID",
                        column: x => x.LearningProgramDetailsID,
                        principalTable: "LearningProgramDetails",
                        principalColumn: "LearningProgramDetailsID");
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaLinksSponsers",
                columns: table => new
                {
                    SocialMediaLinksSponsorsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLinksSponsers", x => x.SocialMediaLinksSponsorsID);
                    table.ForeignKey(
                        name: "FK_SocialMediaLinksSponsers_Sponsor_SponsorID",
                        column: x => x.SponsorID,
                        principalTable: "Sponsor",
                        principalColumn: "SponsorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SponsorLearningProgram",
                columns: table => new
                {
                    SponsorLearningProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningProgramDetailsID = table.Column<int>(type: "int", nullable: true),
                    SponsorID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorLearningProgram", x => x.SponsorLearningProgramID);
                    table.ForeignKey(
                        name: "FK_SponsorLearningProgram_LearningProgramDetails_LearningProgramDetailsID",
                        column: x => x.LearningProgramDetailsID,
                        principalTable: "LearningProgramDetails",
                        principalColumn: "LearningProgramDetailsID");
                    table.ForeignKey(
                        name: "FK_SponsorLearningProgram_Sponsor_SponsorID",
                        column: x => x.SponsorID,
                        principalTable: "Sponsor",
                        principalColumn: "SponsorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StreetID",
                table: "AspNetUsers",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserImageID",
                table: "AspNetUsers",
                column: "UserImageID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceID",
                table: "City",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentID",
                table: "Country",
                column: "ContinentID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CurrencyID",
                table: "Country",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_LanguageID",
                table: "Country",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimezone_CountryID",
                table: "CountryTimezone",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimezone_TimezoneID",
                table: "CountryTimezone",
                column: "TimezoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentStatusID",
                table: "Enrollments",
                column: "EnrollmentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ID",
                table: "Enrollments",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_LearningProgramDetailsID",
                table: "Enrollments",
                column: "LearningProgramDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_PaymentStatusID",
                table: "Enrollments",
                column: "PaymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLearningProgram_InstructorID",
                table: "InstructorLearningProgram",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLearningProgram_LearningProgramDetailsID",
                table: "InstructorLearningProgram",
                column: "LearningProgramDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSkills_InstructorID",
                table: "InstructorSkills",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSkills_SkillsID",
                table: "InstructorSkills",
                column: "SkillsID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSpecialization_InstructorID",
                table: "InstructorSpecialization",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSpecialization_SpecializationID",
                table: "InstructorSpecialization",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgramDetails_LearningProgramStatusID",
                table: "LearningProgramDetails",
                column: "LearningProgramStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgramDetails_LearningProgramTypeID",
                table: "LearningProgramDetails",
                column: "LearningProgramTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgramDetails_LocationID",
                table: "LearningProgramDetails",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgramSpecialization_LearningProgramDetailsID",
                table: "LearningProgramSpecialization",
                column: "LearningProgramDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgramSpecialization_SpecializationID",
                table: "LearningProgramSpecialization",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_StreetID",
                table: "Location",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_StreetID",
                table: "Participant",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantSpecialization_ParticipantID",
                table: "ParticipantSpecialization",
                column: "ParticipantID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantSpecialization_SpecializationID",
                table: "ParticipantSpecialization",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_Partnership_LocationID",
                table: "Partnership",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioMedia_FileTypesID",
                table: "PortfolioMedia",
                column: "FileTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioMedia_LearningProgramDetailsID",
                table: "PortfolioMedia",
                column: "LearningProgramDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryID",
                table: "Province",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SpecializationID",
                table: "Skills",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLinksSponsers_SponsorID",
                table: "SocialMediaLinksSponsers",
                column: "SponsorID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaProfilesInstructor_InstructorID",
                table: "SocialMediaProfilesInstructor",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_LocationID",
                table: "Sponsor",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorLearningProgram_LearningProgramDetailsID",
                table: "SponsorLearningProgram",
                column: "LearningProgramDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorLearningProgram_SponsorID",
                table: "SponsorLearningProgram",
                column: "SponsorID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_CityID",
                table: "Street",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_FileTypesID",
                table: "UserImage",
                column: "FileTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_StreetID",
                table: "Volunteer",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkills_SkillsID",
                table: "VolunteerSkills",
                column: "SkillsID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkills_VolunteerID",
                table: "VolunteerSkills",
                column: "VolunteerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CountryTimezone");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "InstructorLearningProgram");

            migrationBuilder.DropTable(
                name: "InstructorSkills");

            migrationBuilder.DropTable(
                name: "InstructorSpecialization");

            migrationBuilder.DropTable(
                name: "LearningProgramSpecialization");

            migrationBuilder.DropTable(
                name: "ParticipantSpecialization");

            migrationBuilder.DropTable(
                name: "Partnership");

            migrationBuilder.DropTable(
                name: "PortfolioMedia");

            migrationBuilder.DropTable(
                name: "SocialMediaLinksSponsers");

            migrationBuilder.DropTable(
                name: "SocialMediaProfilesInstructor");

            migrationBuilder.DropTable(
                name: "SponsorLearningProgram");

            migrationBuilder.DropTable(
                name: "VolunteerSkills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Timezone");

            migrationBuilder.DropTable(
                name: "EnrollmentStatus");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "LearningProgramDetails");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.DropTable(
                name: "LearningProgramStatus");

            migrationBuilder.DropTable(
                name: "LearningProgramType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
