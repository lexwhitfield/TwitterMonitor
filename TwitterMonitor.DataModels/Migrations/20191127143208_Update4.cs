using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstituencyNew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ConstituencyTypeId = table.Column<int>(nullable: true),
                    PrevConstituencyId = table.Column<string>(nullable: true),
                    OldDodsId = table.Column<int>(nullable: true),
                    OldDisId = table.Column<int>(nullable: true),
                    ClerksConstituencyId = table.Column<int>(nullable: true),
                    GisId = table.Column<int>(nullable: true),
                    PcaCode = table.Column<int>(nullable: true),
                    PconName = table.Column<string>(nullable: true),
                    OsName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    OnsCode = table.Column<string>(nullable: true),
                    SchoolsSubsidyBand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyNew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstituencyNew_ConstituencyType_ConstituencyTypeId",
                        column: x => x.ConstituencyTypeId,
                        principalTable: "ConstituencyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyNew_ConstituencyTypeId",
                table: "ConstituencyNew",
                column: "ConstituencyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstituencyNew");
        }
    }
}
