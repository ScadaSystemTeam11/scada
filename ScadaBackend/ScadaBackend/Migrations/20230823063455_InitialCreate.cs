using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScadaBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalogInput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Driver = table.Column<string>(type: "text", nullable: false),
                    ScanTime = table.Column<float>(type: "real", nullable: false),
                    OnOffScan = table.Column<bool>(type: "boolean", nullable: false),
                    LowLimit = table.Column<float>(type: "real", nullable: false),
                    HighLimit = table.Column<float>(type: "real", nullable: false),
                    Units = table.Column<string>(type: "text", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IOAddress = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalogInput", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AnalogOutput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialValue = table.Column<float>(type: "real", nullable: false),
                    LowLimit = table.Column<float>(type: "real", nullable: false),
                    HighLimit = table.Column<float>(type: "real", nullable: false),
                    Units = table.Column<string>(type: "text", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IOAddress = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalogOutput", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DigitalInput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ScanTime = table.Column<float>(type: "real", nullable: false),
                    OnOffScan = table.Column<bool>(type: "boolean", nullable: false),
                    Driver = table.Column<string>(type: "text", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IOAddress = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalInput", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DigitalOutput",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialValue = table.Column<float>(type: "real", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IOAddress = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalOutput", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TagChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueLimit = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    TagID = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AnalogInputID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alarms_AnalogInput_AnalogInputID",
                        column: x => x.AnalogInputID,
                        principalTable: "AnalogInput",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AlarmAlerts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    AlarmID = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmAlerts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlarmAlerts_Alarms_AlarmID",
                        column: x => x.AlarmID,
                        principalTable: "Alarms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmAlerts_AlarmID",
                table: "AlarmAlerts",
                column: "AlarmID");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_AnalogInputID",
                table: "Alarms",
                column: "AnalogInputID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmAlerts");

            migrationBuilder.DropTable(
                name: "AnalogOutput");

            migrationBuilder.DropTable(
                name: "DigitalInput");

            migrationBuilder.DropTable(
                name: "DigitalOutput");

            migrationBuilder.DropTable(
                name: "TagChange");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "AnalogInput");
        }
    }
}
