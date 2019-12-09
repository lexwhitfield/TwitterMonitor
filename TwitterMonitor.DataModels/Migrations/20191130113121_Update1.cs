using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OppositionPostMembers_OppositionPosts_OppositionPostId",
            //    table: "OppositionPostMembers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OppositionPosts_OppositionRanks_OppositionRankId",
            //    table: "OppositionPosts");

            //migrationBuilder.DropColumn(
            //    name: "GovernmentPostId",
            //    table: "OppositionPostMembers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "OppositionRankId",
            //    table: "OppositionPosts",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "INTEGER");

            //migrationBuilder.AlterColumn<int>(
            //    name: "OppositionPostId",
            //    table: "OppositionPostMembers",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "INTEGER",
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PartyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartyId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartyMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartyMembers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartyMembers_MemberId",
                table: "PartyMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyMembers_PartyId",
                table: "PartyMembers",
                column: "PartyId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OppositionPostMembers_OppositionPosts_OppositionPostId",
            //    table: "OppositionPostMembers",
            //    column: "OppositionPostId",
            //    principalTable: "OppositionPosts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OppositionPosts_OppositionRanks_OppositionRankId",
            //    table: "OppositionPosts",
            //    column: "OppositionRankId",
            //    principalTable: "OppositionRanks",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OppositionPostMembers_OppositionPosts_OppositionPostId",
                table: "OppositionPostMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OppositionPosts_OppositionRanks_OppositionRankId",
                table: "OppositionPosts");

            migrationBuilder.DropTable(
                name: "PartyMembers");

            migrationBuilder.AlterColumn<int>(
                name: "OppositionRankId",
                table: "OppositionPosts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OppositionPostId",
                table: "OppositionPostMembers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GovernmentPostId",
                table: "OppositionPostMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OppositionPostMembers_OppositionPosts_OppositionPostId",
                table: "OppositionPostMembers",
                column: "OppositionPostId",
                principalTable: "OppositionPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OppositionPosts_OppositionRanks_OppositionRankId",
                table: "OppositionPosts",
                column: "OppositionRankId",
                principalTable: "OppositionRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
