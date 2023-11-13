using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalbeTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_molecules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoleculesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MolDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_molecules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_study_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_study",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    ProtocolTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoleculesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyStatusID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_study_m_molecules_MoleculesID",
                        column: x => x.MoleculesID,
                        principalTable: "m_molecules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_m_study_m_study_status_StudyStatusID",
                        column: x => x.StudyStatusID,
                        principalTable: "m_study_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_study_MoleculesID",
                table: "m_study",
                column: "MoleculesID");

            migrationBuilder.CreateIndex(
                name: "IX_m_study_StudyStatusID",
                table: "m_study",
                column: "StudyStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_study");

            migrationBuilder.DropTable(
                name: "m_molecules");

            migrationBuilder.DropTable(
                name: "m_study_status");
        }
    }
}
