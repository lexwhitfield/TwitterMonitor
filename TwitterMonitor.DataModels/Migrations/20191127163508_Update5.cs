using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstituencyArea",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConstituencyId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstituencyArea_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituencyArea_ConstituencyNew_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "ConstituencyNew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyArea_AreaId",
                table: "ConstituencyArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyArea_ConstituencyId",
                table: "ConstituencyArea",
                column: "ConstituencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstituencyArea");
        }
    }
}
