using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QMS.Database.Migrations
{
    public partial class InitialBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "OrderNumbers",
                schema: "shared");

            migrationBuilder.CreateTable(
                name: "AppNavigation",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsInitialPage = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMainModule = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 428, DateTimeKind.Unspecified).AddTicks(7023), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNavigation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EpmsCampaignID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 468, DateTimeKind.Unspecified).AddTicks(8305), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormCategory",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 470, DateTimeKind.Unspecified).AddTicks(8305), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormChoice",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR shared.OrderNumbers"),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 474, DateTimeKind.Unspecified).AddTicks(4839), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormChoice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormType",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 488, DateTimeKind.Unspecified).AddTicks(8152), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 501, DateTimeKind.Unspecified).AddTicks(13), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("60066c26-fc5c-4f61-9d50-176ab47c80a5")),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 509, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lob",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 493, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lob", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lob_Campaign_CampaignID",
                        column: x => x.CampaignID,
                        principalSchema: "dbo",
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HtmlControl",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FormTypeID = table.Column<long>(type: "bigint", nullable: true),
                    FormCategoryID = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 491, DateTimeKind.Unspecified).AddTicks(4371), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlControl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HtmlControl_FormCategory_FormCategoryID",
                        column: x => x.FormCategoryID,
                        principalSchema: "dbo",
                        principalTable: "FormCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HtmlControl_FormType_FormTypeID",
                        column: x => x.FormTypeID,
                        principalSchema: "dbo",
                        principalTable: "FormType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleAppNavigation",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppNavigationID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 498, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAppNavigation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleAppNavigation_AppNavigation_AppNavigationID",
                        column: x => x.AppNavigationID,
                        principalSchema: "dbo",
                        principalTable: "AppNavigation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAppNavigation_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("58a1327a-6201-42c5-a317-97a503ea4dff")),
                    FormTypeID = table.Column<long>(type: "bigint", nullable: false),
                    FormCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsNoteVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 478, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Form_FormCategory_FormCategoryID",
                        column: x => x.FormCategoryID,
                        principalSchema: "dbo",
                        principalTable: "FormCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_FormType_FormTypeID",
                        column: x => x.FormTypeID,
                        principalSchema: "dbo",
                        principalTable: "FormType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_User_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCampaign",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: true),
                    CampaignID = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 505, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaign", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCampaign_Campaign_CampaignID",
                        column: x => x.CampaignID,
                        principalSchema: "dbo",
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserCampaign_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 512, DateTimeKind.Unspecified).AddTicks(4004), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<long>(type: "bigint", nullable: false),
                    TeammateID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FormNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 440, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Audit_Form_FormID",
                        column: x => x.FormID,
                        principalSchema: "dbo",
                        principalTable: "Form",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_User_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Audit_User_TeammateID",
                        column: x => x.TeammateID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FormQuestion",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HtmlControlID = table.Column<long>(type: "bigint", nullable: false),
                    IsNoteVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR shared.OrderNumbers"),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 485, DateTimeKind.Unspecified).AddTicks(9712), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormQuestion_Form_FormID",
                        column: x => x.FormID,
                        principalSchema: "dbo",
                        principalTable: "Form",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormQuestion_HtmlControl_HtmlControlID",
                        column: x => x.HtmlControlID,
                        principalSchema: "dbo",
                        principalTable: "HtmlControl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditDetail",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditID = table.Column<long>(type: "bigint", nullable: false),
                    QuestionID = table.Column<long>(type: "bigint", nullable: true),
                    ChoiceID = table.Column<long>(type: "bigint", nullable: true),
                    QuestionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 461, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditDetail_Audit_AuditID",
                        column: x => x.AuditID,
                        principalSchema: "dbo",
                        principalTable: "Audit",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditDetail_FormChoice_ChoiceID",
                        column: x => x.ChoiceID,
                        principalSchema: "dbo",
                        principalTable: "FormChoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AuditDetail_FormQuestion_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "dbo",
                        principalTable: "FormQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AuditDetail_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormQuestionChoice",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionID = table.Column<long>(type: "bigint", nullable: false),
                    ChoiceID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 481, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestionChoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormQuestionChoice_FormChoice_ChoiceID",
                        column: x => x.ChoiceID,
                        principalSchema: "dbo",
                        principalTable: "FormChoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormQuestionChoice_FormQuestion_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "dbo",
                        principalTable: "FormQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[] { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 8, 0, 0, 0)), null, "User management navigation", true, null, "user" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 13L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 8, 0, 0, 0)), null, "Audit/report details view", null, "audit-details-view" },
                    { 12L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 8, 0, 0, 0)), null, "Admin - Form Create Update", null, "form-update" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsInitialPage", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 11L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 8, 0, 0, 0)), null, "TM - Audit Summary", true, true, null, "report-TM" },
                    { 10L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6840), new TimeSpan(0, 8, 0, 0, 0)), null, "TL - Audit Summary", true, true, null, "report-tl" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 8L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 8, 0, 0, 0)), null, "QA - Audit Record Create", null, "audit-create" },
                    { 9L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, 8, 0, 0, 0)), null, "QA - Report", null, "report-qa" },
                    { 6L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 8, 0, 0, 0)), null, "QA - Form Create Update", null, "form-createupdate-qa" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[] { 5L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 8, 0, 0, 0)), null, "QA - Form Management", true, null, "form-qa" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsInitialPage", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[] { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 8, 0, 0, 0)), null, "Admin - Audit Summary", true, true, null, "report-admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "ModifiedByID", "Name" },
                values: new object[] { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 8, 0, 0, 0)), null, "Admin - Form Create Update", null, "form-create" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[] { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6702), new TimeSpan(0, 8, 0, 0, 0)), null, "Admin - Form Management", true, null, "form-admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppNavigation",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "IsInitialPage", "IsMainModule", "ModifiedByID", "Name" },
                values: new object[] { 7L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 521, DateTimeKind.Unspecified).AddTicks(6768), new TimeSpan(0, 8, 0, 0, 0)), null, "QA - Audit Record List", true, true, null, "audit-qa" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Campaign",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "EpmsCampaignID", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 514, DateTimeKind.Unspecified).AddTicks(3549), new TimeSpan(0, 8, 0, 0, 0)), null, 1389L, null, "Finance" },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 514, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 8, 0, 0, 0)), null, 420L, null, "IT" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 514, DateTimeKind.Unspecified).AddTicks(3507), new TimeSpan(0, 8, 0, 0, 0)), null, 22L, null, "Operations" },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 514, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 8, 0, 0, 0)), null, 373L, null, "Data Science" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormCategory",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 524, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Multiple Choices Form" },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 524, DateTimeKind.Unspecified).AddTicks(3680), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Yes/No/NA Form" },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 524, DateTimeKind.Unspecified).AddTicks(3637), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Yes | No Form" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 524, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 8, 0, 0, 0)), null, null, "True | False Form" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormChoice",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "Name", "SortOrder", "Value" },
                values: new object[,]
                {
                    { 23L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5603), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Agent used unfamiliar language", 23, 4 },
                    { 24L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5605), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Poor Communication (voice/format/text)", 24, 3 },
                    { 25L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5608), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Meets Expecations", 25, 10 },
                    { 26L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Agent used inapproriate language", 26, -25 },
                    { 27L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5612), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Agent cursed, yelled, was rude", 27, -25 },
                    { 28L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Excessive hold time", 28, 10 },
                    { 29L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Meets Expectations", 29, 10 },
                    { 30L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Did not link with correct delivery/email", 30, -25 },
                    { 31L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5668), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Did not link with correct delivery/email", 31, -25 },
                    { 32L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not duplicate/merge cases", 32, 5 },
                    { 34L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not set case status appropriately", 34, 5 },
                    { 35L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not select correct Issue/Issue Cat", 35, 1 },
                    { 36L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5678), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Incorrect Resolution/Category", 36, 1 },
                    { 37L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5680), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not associate correct account name", 37, 1 },
                    { 38L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5683), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not log call to the case", 38, 1 },
                    { 39L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5685), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not update to correct case origin", 39, 1 },
                    { 40L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5687), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Meets Expectations", 40, 20 },
                    { 33L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not include sufficient case notes", 33, 5 },
                    { 21L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5599), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Meets Expectations", 21, 35 },
                    { 22L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5601), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Agent was not easy to understand", 22, 3 },
                    { 19L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5595), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Escalated without appropriate case notes", 19, 10 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormChoice",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "Name", "SortOrder", "Value" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Yes", 1, 1 },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5557), new TimeSpan(0, 8, 0, 0, 0)), null, null, "No", 2, 0 },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5560), new TimeSpan(0, 8, 0, 0, 0)), null, null, "NA", 3, 2 },
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 8, 0, 0, 0)), null, null, "True", 4, 1 },
                    { 5L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 8, 0, 0, 0)), null, null, "False", 5, 0 },
                    { 6L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5567), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Agent shared private information", 6, -25 },
                    { 7L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5569), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Did not take ownership of the case", 7, -25 },
                    { 8L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5571), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Did not use/complete WFT", 8, -25 },
                    { 20L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5597), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Failed to follow through with request", 20, 15 },
                    { 9L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Process was not followed", 9, 7 },
                    { 11L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5578), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not attach KB as appropriate", 11, 7 },
                    { 12L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5580), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Did not follow CSAT positioning", 12, 1 },
                    { 13L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Meets Expectations", 13, 25 },
                    { 14L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5584), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Failure to properly follow-up/escalate", 14, -25 },
                    { 15L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5587), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] - Agent failed to OB on dropped contact", 15, -25 },
                    { 16L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5589), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Did not correctly escalate Covid-19 case", 16, -25 },
                    { 17L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 8, 0, 0, 0)), null, null, "[CRITICAL ERROR] Failed to escalate a HSL case", 17, -25 },
                    { 18L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5593), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Transferred without a justified reason", 18, 10 },
                    { 10L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 527, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Provided inaccurate information", 10, 10 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormType",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(8985), new TimeSpan(0, 8, 0, 0, 0)), null, null, "QA Form" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 8, 0, 0, 0)), null, null, "Survey Form" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HtmlControl",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormCategoryID", "FormTypeID", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, "Checkbox" },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(5149), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, "Textbox" },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(5071), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, "Option" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, "Dropdown" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 516, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 8, 0, 0, 0)), null, "Administrator", null, "Administrator" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 516, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 8, 0, 0, 0)), null, "QA", null, "QA" },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 516, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, 8, 0, 0, 0)), null, "TL", null, "TL" },
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 516, DateTimeKind.Unspecified).AddTicks(216), new TimeSpan(0, 8, 0, 0, 0)), null, "TM", null, "TM" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Email", "FirstName", "Key", "LastName", "MiddleName", "ModifiedByID", "Password", "Username" },
                values: new object[,]
                {
                    { 14L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 8, 0, 0, 0)), null, "roel.bernal@email.com", "Roel", new Guid("b89e8918-0952-4546-883d-efb54095619e"), "Bernal", "V", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1605003" },
                    { 13L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8086), new TimeSpan(0, 8, 0, 0, 0)), null, "bella.flores@email.com", "Bella", new Guid("a86cd837-1c50-49de-82bd-93203717fe3e"), "Flores", "S", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1605002" },
                    { 12L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 8, 0, 0, 0)), null, "evag.yariv@email.com", "Evag", new Guid("a0215166-0718-4d4f-957c-7a104b533884"), "Yariv", "D", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1605001" },
                    { 11L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8082), new TimeSpan(0, 8, 0, 0, 0)), null, "kitty.chicha@email.com", "Kitty Chicha", new Guid("74e8db5d-e9c9-47a1-b793-ba6ccb09c404"), "Amatayakul", "Z", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1605000" },
                    { 10L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 8, 0, 0, 0)), null, "charlie.davao@email.com", "Charlie", new Guid("295bfad2-997f-40af-a50c-b2b76e558a5e"), "Davao", "G", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604999" },
                    { 9L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8076), new TimeSpan(0, 8, 0, 0, 0)), null, "max.alvarado@email.com", "Max", new Guid("f472a092-dc4c-4fa3-90d9-5a86eea5aa38"), "Alvarado", "G", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604998" },
                    { 8L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 8, 0, 0, 0)), null, "jimmy.santos@email.com", "Ace", new Guid("4bd2ef61-0fb8-4fa7-a3b9-39c63060336c"), "Vergel", "H", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604997" },
                    { 5L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 8, 0, 0, 0)), null, "dick.israel@email.com", "Dick", new Guid("6b8538a5-5163-4b0d-902f-24b59cc00375"), "Israel", "D", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604994" },
                    { 6L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 8, 0, 0, 0)), null, "rex.cortez@email.com", "Rex", new Guid("edc4150f-2723-4a38-bc59-f6fd1737d236"), "Cortez", "E", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604995" },
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 8, 0, 0, 0)), null, "vic.diaz@email.com", "Vic", new Guid("480dd49e-7bb8-4df1-bd16-c9592f3be5be"), "Diaz", "C", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604990" },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8061), new TimeSpan(0, 8, 0, 0, 0)), null, "romy.diaz@email.com", "Romy", new Guid("73d4794b-76db-4ddd-816c-e8e25f89e756"), "Diaz", "B", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604992" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 8, 0, 0, 0)), null, "pacquito.diaz@email.com", "Pacquito", new Guid("72b5a528-6838-4dc2-a889-30a47db1ce07"), "Diaz", "B", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604991" },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 8, 0, 0, 0)), null, "mcnielv@gmail.com", "McNiel", new Guid("a891cec8-0808-4cde-a42e-495634b0af03"), "Viray", "N", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604993" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Email", "FirstName", "Key", "LastName", "MiddleName", "ModifiedByID", "Password", "Username" },
                values: new object[] { 7L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 8, 0, 0, 0)), null, "ace.vergel@email.com", "Jimmy", new Guid("d5fa1bed-9a40-45f9-8e09-bc2b103e9be6"), "Santos", "F", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1604996" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Email", "FirstName", "Key", "LastName", "MiddleName", "ModifiedByID", "Password", "Username" },
                values: new object[] { 15L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 517, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 8, 0, 0, 0)), null, "ohdet.khan@email.com", "Ohdet", new Guid("c1007d8c-3d00-4264-b93e-d9e04e420197"), "Khan", "R", null, "Jaemp2W0c4pSRQ8SMICEvg==", "1605004" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Form",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormCategoryID", "FormTypeID", "IsNoteVisible", "Key", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 525, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, true, new Guid("73d4794b-76db-4ddd-816c-e8e25f89e756"), null, "QA Form 3" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 525, DateTimeKind.Unspecified).AddTicks(965), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 1L, true, new Guid("72b5a528-6838-4dc2-a889-30a47db1ce07"), null, "QA Form 2" },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 525, DateTimeKind.Unspecified).AddTicks(834), new TimeSpan(0, 8, 0, 0, 0)), null, 4L, 1L, true, new Guid("a891cec8-0808-4cde-a42e-495634b0af03"), null, "QA Form 1" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleAppNavigation",
                columns: new[] { "ID", "Active", "AppNavigationID", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "RoleID" },
                values: new object[,]
                {
                    { 1L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 17L, true, 13L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(93), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L },
                    { 11L, true, 11L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(81), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L },
                    { 10L, true, 10L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(79), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L },
                    { 15L, true, 13L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(89), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 13L, true, 12L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(85), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 9L, true, 9L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 16L, true, 13L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L },
                    { 7L, true, 7L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(72), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 6L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 5L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(68), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L },
                    { 14L, true, 13L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(87), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 12L, true, 12L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 4L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(66), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 3L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(64), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 2L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(60), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 8L, true, 8L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 523, DateTimeKind.Unspecified).AddTicks(74), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserCampaign",
                columns: new[] { "ID", "Active", "CampaignID", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "UserID" },
                values: new object[,]
                {
                    { 9L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2426), new TimeSpan(0, 8, 0, 0, 0)), null, null, 8L },
                    { 10L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2428), new TimeSpan(0, 8, 0, 0, 0)), null, null, 9L },
                    { 11L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 8, 0, 0, 0)), null, null, 10L },
                    { 12L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2432), new TimeSpan(0, 8, 0, 0, 0)), null, null, 11L },
                    { 16L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 8, 0, 0, 0)), null, null, 15L },
                    { 14L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 8, 0, 0, 0)), null, null, 13L },
                    { 15L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2439), new TimeSpan(0, 8, 0, 0, 0)), null, null, 14L },
                    { 8L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 8, 0, 0, 0)), null, null, 7L },
                    { 13L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2435), new TimeSpan(0, 8, 0, 0, 0)), null, null, 12L },
                    { 7L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, 8, 0, 0, 0)), null, null, 6L },
                    { 4L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L },
                    { 6L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, 8, 0, 0, 0)), null, null, 5L },
                    { 1L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2346), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 2L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L },
                    { 5L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L },
                    { 17L, true, 4L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 8, 0, 0, 0)), null, null, 15L },
                    { 3L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 520, DateTimeKind.Unspecified).AddTicks(2412), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "RoleID", "UserID" },
                values: new object[,]
                {
                    { 14L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 14L },
                    { 13L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8348), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 13L },
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8211), new TimeSpan(0, 8, 0, 0, 0)), null, null, 1L, 1L },
                    { 12L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8346), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 12L },
                    { 11L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 11L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "RoleID", "UserID" },
                values: new object[,]
                {
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8279), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 2L },
                    { 10L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L, 10L },
                    { 9L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8340), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L, 9L },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8283), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L, 3L },
                    { 8L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8338), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 8L },
                    { 7L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 8, 0, 0, 0)), null, null, 4L, 7L },
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8285), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L, 4L },
                    { 6L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8290), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L, 6L },
                    { 5L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8288), new TimeSpan(0, 8, 0, 0, 0)), null, null, 3L, 5L },
                    { 15L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 518, DateTimeKind.Unspecified).AddTicks(8352), new TimeSpan(0, 8, 0, 0, 0)), null, null, 2L, 15L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "IsNoteVisible", "ModifiedByID", "Name", "SortOrder" },
                values: new object[] { 27L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3842), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Date", 27 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 9L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 1L, null, "Documentation", 9 },
                    { 10L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3753), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 1L, null, "Process Adherance", 10 },
                    { 11L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3755), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 1L, null, "Transfers and Follow-ups", 11 },
                    { 12L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 1L, null, "Language, Grammar & Formatting", 12 },
                    { 13L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3760), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 1L, null, "Professional Conduct", 13 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "IsNoteVisible", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 14L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3762), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Date", 14 },
                    { 15L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Teammate", 15 },
                    { 8L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3749), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "What is the resolution provided by the TM?", 8 },
                    { 16L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3767), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Case ID", 16 },
                    { 18L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3772), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Resolution", 18 },
                    { 19L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3774), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Delivery ID", 19 },
                    { 20L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3776), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "What is the issue of the Cx?", 20 },
                    { 21L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "What is the resolution provided by the TM?", 21 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 22L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, null, "Documentation", 22 },
                    { 23L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3783), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, null, "Process Adherance", 23 },
                    { 24L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3785), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, null, "Transfers and Follow-ups", 24 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "IsNoteVisible", "ModifiedByID", "Name", "SortOrder" },
                values: new object[] { 17L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3770), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 3L, true, null, "Issue", 17 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "ModifiedByID", "Name", "SortOrder" },
                values: new object[] { 25L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, null, "Language, Grammar & Formatting", 25 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "IsNoteVisible", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 7L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3746), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "What is the issue of the Cx?", 7 },
                    { 5L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3742), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Resolution", 5 },
                    { 28L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3844), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Teammate", 28 },
                    { 29L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3846), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Case ID", 29 },
                    { 30L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Issue", 30 },
                    { 31L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3851), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Resolution", 31 },
                    { 32L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "Delivery ID", 32 },
                    { 33L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3856), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "What is the issue of the Cx?", 33 },
                    { 34L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3858), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 3L, true, null, "What is the resolution provided by the TM?", 34 },
                    { 6L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3744), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Delivery ID", 6 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 35L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3861), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 4L, null, "Documentation", 35 },
                    { 37L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3865), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 4L, null, "Transfers and Follow-ups", 37 },
                    { 38L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3868), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 4L, null, "Language, Grammar & Formatting", 38 },
                    { 39L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3871), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 4L, null, "Professional Conduct", 39 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "IsNoteVisible", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Date", 1 },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Teammate", 2 },
                    { 3L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3736), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Case ID", 3 },
                    { 4L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3739), new TimeSpan(0, 8, 0, 0, 0)), null, 2L, 3L, true, null, "Issue", 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestion",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "FormID", "HtmlControlID", "ModifiedByID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 36L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3863), new TimeSpan(0, 8, 0, 0, 0)), null, 1L, 4L, null, "Process Adherance", 36 },
                    { 26L, true, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 530, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 8, 0, 0, 0)), null, 3L, 1L, null, "Professional Conduct", 26 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestionChoice",
                columns: new[] { "ID", "Active", "ChoiceID", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "QuestionID" },
                values: new object[,]
                {
                    { 26L, true, 31L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6366), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 58L, true, 28L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, 8, 0, 0, 0)), null, null, 39L },
                    { 59L, true, 29L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6507), new TimeSpan(0, 8, 0, 0, 0)), null, null, 39L },
                    { 60L, true, 30L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6509), new TimeSpan(0, 8, 0, 0, 0)), null, null, 39L },
                    { 1L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 8, 0, 0, 0)), null, null, 9L },
                    { 2L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6316), new TimeSpan(0, 8, 0, 0, 0)), null, null, 9L },
                    { 3L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6319), new TimeSpan(0, 8, 0, 0, 0)), null, null, 10L },
                    { 4L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6321), new TimeSpan(0, 8, 0, 0, 0)), null, null, 10L },
                    { 5L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6323), new TimeSpan(0, 8, 0, 0, 0)), null, null, 11L },
                    { 6L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 8, 0, 0, 0)), null, null, 11L },
                    { 7L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6327), new TimeSpan(0, 8, 0, 0, 0)), null, null, 12L },
                    { 8L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 8, 0, 0, 0)), null, null, 12L },
                    { 9L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6331), new TimeSpan(0, 8, 0, 0, 0)), null, null, 13L },
                    { 57L, true, 27L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 8, 0, 0, 0)), null, null, 39L },
                    { 10L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6333), new TimeSpan(0, 8, 0, 0, 0)), null, null, 13L },
                    { 12L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6337), new TimeSpan(0, 8, 0, 0, 0)), null, null, 22L },
                    { 13L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 8, 0, 0, 0)), null, null, 22L },
                    { 14L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6341), new TimeSpan(0, 8, 0, 0, 0)), null, null, 23L },
                    { 15L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6343), new TimeSpan(0, 8, 0, 0, 0)), null, null, 23L },
                    { 16L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 8, 0, 0, 0)), null, null, 23L },
                    { 17L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6347), new TimeSpan(0, 8, 0, 0, 0)), null, null, 24L },
                    { 18L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6349), new TimeSpan(0, 8, 0, 0, 0)), null, null, 24L },
                    { 19L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6352), new TimeSpan(0, 8, 0, 0, 0)), null, null, 24L },
                    { 20L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6354), new TimeSpan(0, 8, 0, 0, 0)), null, null, 25L },
                    { 21L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6355), new TimeSpan(0, 8, 0, 0, 0)), null, null, 25L },
                    { 22L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 8, 0, 0, 0)), null, null, 25L },
                    { 23L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 8, 0, 0, 0)), null, null, 26L },
                    { 11L, true, 1L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6335), new TimeSpan(0, 8, 0, 0, 0)), null, null, 22L },
                    { 56L, true, 26L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6501), new TimeSpan(0, 8, 0, 0, 0)), null, null, 39L },
                    { 55L, true, 25L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6499), new TimeSpan(0, 8, 0, 0, 0)), null, null, 38L },
                    { 54L, true, 24L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6497), new TimeSpan(0, 8, 0, 0, 0)), null, null, 38L },
                    { 27L, true, 32L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 28L, true, 33L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 29L, true, 34L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6445), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 30L, true, 35L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6448), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 31L, true, 36L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 32L, true, 37L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6451), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 33L, true, 38L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6453), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 34L, true, 39L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6455), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 35L, true, 40L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 8, 0, 0, 0)), null, null, 35L },
                    { 36L, true, 6L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6460), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 37L, true, 7L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6462), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormQuestionChoice",
                columns: new[] { "ID", "Active", "ChoiceID", "CreatedByID", "DateCreated", "DateModified", "ModifiedByID", "QuestionID" },
                values: new object[,]
                {
                    { 38L, true, 8L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 39L, true, 9L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 40L, true, 10L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6467), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 41L, true, 11L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6470), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 42L, true, 12L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 43L, true, 13L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6474), new TimeSpan(0, 8, 0, 0, 0)), null, null, 36L },
                    { 44L, true, 14L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6476), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 45L, true, 15L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6478), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 46L, true, 16L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6480), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 47L, true, 17L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6482), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 48L, true, 18L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 49L, true, 19L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 50L, true, 20L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6489), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 51L, true, 21L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6491), new TimeSpan(0, 8, 0, 0, 0)), null, null, 37L },
                    { 52L, true, 22L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6493), new TimeSpan(0, 8, 0, 0, 0)), null, null, 38L },
                    { 53L, true, 23L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 8, 0, 0, 0)), null, null, 38L },
                    { 24L, true, 2L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6362), new TimeSpan(0, 8, 0, 0, 0)), null, null, 26L },
                    { 25L, true, 3L, 1L, new DateTimeOffset(new DateTime(2021, 6, 5, 13, 7, 13, 533, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 8, 0, 0, 0)), null, null, 26L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNavigation_Name",
                schema: "dbo",
                table: "AppNavigation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CreatedByID",
                schema: "dbo",
                table: "Audit",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_FormID",
                schema: "dbo",
                table: "Audit",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_TeammateID",
                schema: "dbo",
                table: "Audit",
                column: "TeammateID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditDetail_AuditID",
                schema: "dbo",
                table: "AuditDetail",
                column: "AuditID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditDetail_ChoiceID",
                schema: "dbo",
                table: "AuditDetail",
                column: "ChoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditDetail_QuestionID",
                schema: "dbo",
                table: "AuditDetail",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditDetail_UserID",
                schema: "dbo",
                table: "AuditDetail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Form_CreatedByID",
                schema: "dbo",
                table: "Form",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Form_FormCategoryID",
                schema: "dbo",
                table: "Form",
                column: "FormCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Form_FormTypeID",
                schema: "dbo",
                table: "Form",
                column: "FormTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_FormID",
                schema: "dbo",
                table: "FormQuestion",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_HtmlControlID",
                schema: "dbo",
                table: "FormQuestion",
                column: "HtmlControlID");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionChoice_ChoiceID",
                schema: "dbo",
                table: "FormQuestionChoice",
                column: "ChoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionChoice_QuestionID",
                schema: "dbo",
                table: "FormQuestionChoice",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlControl_FormCategoryID",
                schema: "dbo",
                table: "HtmlControl",
                column: "FormCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlControl_FormTypeID",
                schema: "dbo",
                table: "HtmlControl",
                column: "FormTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Lob_CampaignID",
                schema: "dbo",
                table: "Lob",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserID",
                schema: "dbo",
                table: "RefreshToken",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                schema: "dbo",
                table: "Role",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAppNavigation_AppNavigationID",
                schema: "dbo",
                table: "RoleAppNavigation",
                column: "AppNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAppNavigation_RoleID",
                schema: "dbo",
                table: "RoleAppNavigation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "dbo",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                schema: "dbo",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_CampaignID",
                schema: "dbo",
                table: "UserCampaign",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_UserID",
                schema: "dbo",
                table: "UserCampaign",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                schema: "dbo",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                schema: "dbo",
                table: "UserRole",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormQuestionChoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Lob",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleAppNavigation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserCampaign",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormChoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormQuestion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppNavigation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Campaign",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Form",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HtmlControl",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormType",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "OrderNumbers",
                schema: "shared");
        }
    }
}
