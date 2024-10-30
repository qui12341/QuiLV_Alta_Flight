using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alta_Flight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    flight_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flight_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pound_of_loading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pound_of_unloading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    document_list_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.flight_ID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Permission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Permission_Id);
                    table.ForeignKey(
                        name: "FK_Permission_Group_group_id",
                        column: x => x.group_id,
                        principalTable: "Group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountID);
                    table.ForeignKey(
                        name: "FK_Account_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    configuration_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.configuration_ID);
                    table.ForeignKey(
                        name: "FK_Configuration_Permission_Permission_Id",
                        column: x => x.Permission_Id,
                        principalTable: "Permission",
                        principalColumn: "Permission_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account_Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountID = table.Column<int>(type: "int", nullable: true),
                    group_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Group_Account_accountID",
                        column: x => x.accountID,
                        principalTable: "Account",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Group_Group_group_id",
                        column: x => x.group_id,
                        principalTable: "Group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpdateVersion",
                columns: table => new
                {
                    Update_Version_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Update_Version_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    accountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateVersion", x => x.Update_Version_ID);
                    table.ForeignKey(
                        name: "FK_UpdateVersion_Account_accountID",
                        column: x => x.accountID,
                        principalTable: "Account",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document_List",
                columns: table => new
                {
                    document_list_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    version = table.Column<float>(type: "real", nullable: false),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    Permission_Id = table.Column<int>(type: "int", nullable: false),
                    Update_Version_ID = table.Column<int>(type: "int", nullable: false),
                    flight_ID = table.Column<int>(type: "int", nullable: false),
                    configuration_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document_List", x => x.document_list_id);
                    table.ForeignKey(
                        name: "FK_Document_List_Account_accountID",
                        column: x => x.accountID,
                        principalTable: "Account",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_List_Configuration_configuration_ID",
                        column: x => x.configuration_ID,
                        principalTable: "Configuration",
                        principalColumn: "configuration_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_List_Permission_Permission_Id",
                        column: x => x.Permission_Id,
                        principalTable: "Permission",
                        principalColumn: "Permission_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_List_UpdateVersion_Update_Version_ID",
                        column: x => x.Update_Version_ID,
                        principalTable: "UpdateVersion",
                        principalColumn: "Update_Version_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flight_Document_List",
                columns: table => new
                {
                    flight_document_lists = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_list_id = table.Column<int>(type: "int", nullable: false),
                    flight_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_Document_List", x => x.flight_document_lists);
                    table.ForeignKey(
                        name: "FK_flight_Document_List_Document_List_document_list_id",
                        column: x => x.document_list_id,
                        principalTable: "Document_List",
                        principalColumn: "document_list_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flight_Document_List_Flight_flight_ID",
                        column: x => x.flight_ID,
                        principalTable: "Flight",
                        principalColumn: "flight_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_role_id",
                table: "Account",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Group_accountID",
                table: "Account_Group",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Group_group_id",
                table: "Account_Group",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Permission_Id",
                table: "Configuration",
                column: "Permission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_List_accountID",
                table: "Document_List",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_List_configuration_ID",
                table: "Document_List",
                column: "configuration_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_List_Permission_Id",
                table: "Document_List",
                column: "Permission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_List_Update_Version_ID",
                table: "Document_List",
                column: "Update_Version_ID");

            migrationBuilder.CreateIndex(
                name: "IX_flight_Document_List_document_list_id",
                table: "flight_Document_List",
                column: "document_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_Document_List_flight_ID",
                table: "flight_Document_List",
                column: "flight_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_group_id",
                table: "Permission",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateVersion_accountID",
                table: "UpdateVersion",
                column: "accountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_Group");

            migrationBuilder.DropTable(
                name: "flight_Document_List");

            migrationBuilder.DropTable(
                name: "Document_List");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "UpdateVersion");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
