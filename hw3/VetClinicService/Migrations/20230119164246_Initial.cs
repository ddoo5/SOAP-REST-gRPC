using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Consumer");

            migrationBuilder.EnsureSchema(
                name: "Job");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Consumer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    docs = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "TEXT", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "TEXT", maxLength: 255, nullable: false),
                    patronymic = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "Consumer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    masterid = table.Column<int>(name: "master_id", type: "INTEGER", nullable: false),
                    moniker = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    birthday = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pets_Clients_master_id",
                        column: x => x.masterid,
                        principalSchema: "Consumer",
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                schema: "Job",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clientid = table.Column<int>(name: "client_id", type: "INTEGER", nullable: false),
                    petid = table.Column<int>(name: "pet_id", type: "INTEGER", nullable: false),
                    consultationdate = table.Column<DateTime>(name: "consultation_date", type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultations_Clients_client_id",
                        column: x => x.clientid,
                        principalSchema: "Consumer",
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultations_Pets_pet_id",
                        column: x => x.petid,
                        principalSchema: "Consumer",
                        principalTable: "Pets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_client_id",
                schema: "Job",
                table: "Consultations",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_pet_id",
                schema: "Job",
                table: "Consultations",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_master_id",
                schema: "Consumer",
                table: "Pets",
                column: "master_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations",
                schema: "Job");

            migrationBuilder.DropTable(
                name: "Pets",
                schema: "Consumer");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Consumer");
        }
    }
}
