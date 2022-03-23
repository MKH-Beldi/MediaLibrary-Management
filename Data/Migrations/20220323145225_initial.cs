using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NbrBorrowsMax = table.Column<int>(type: "int", nullable: false),
                    Contribution = table.Column<string>(type: "text", nullable: true),
                    RateCoef = table.Column<double>(type: "double", nullable: false),
                    DurationCoef = table.Column<double>(type: "double", nullable: false),
                    ReductionCodeEnable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaLibraries",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLibraries", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReductionCode = table.Column<int>(type: "int", nullable: false),
                    CategoryFK = table.Column<int>(type: "int", nullable: true),
                    MediaLibraryFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Categories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Clients_MediaLibraries_MediaLibraryFK",
                        column: x => x.MediaLibraryFK,
                        principalTable: "MediaLibraries",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    MediaLibraryKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Documents_MediaLibraries_MediaLibraryKey",
                        column: x => x.MediaLibraryKey,
                        principalTable: "MediaLibraries",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Audios_Documents_Key",
                        column: x => x.Key,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    NbrPage = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Books_Documents_Key",
                        column: x => x.Key,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    BorrowDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    DocumentFK = table.Column<int>(type: "int", nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReminderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rate = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => new { x.ClientFK, x.DocumentFK, x.BorrowDate });
                    table.ForeignKey(
                        name: "FK_Borrows_Clients_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Documents_DocumentFK",
                        column: x => x.DocumentFK,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MovieDuration = table.Column<int>(type: "int", nullable: false),
                    LegalNotice = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Videos_Documents_Key",
                        column: x => x.Key,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_DocumentFK",
                table: "Borrows",
                column: "DocumentFK");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CategoryFK",
                table: "Clients",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MediaLibraryFK",
                table: "Clients",
                column: "MediaLibraryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MediaLibraryKey",
                table: "Documents",
                column: "MediaLibraryKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MediaLibraries");
        }
    }
}
