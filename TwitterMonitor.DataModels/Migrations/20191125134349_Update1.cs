using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {       
            migrationBuilder.CreateTable(
                name: "ConstituencyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyType", x => x.Id);
                });

            //migrationBuilder.AddColumn<int>(
            //    name: "ConstituencyTypeId",
            //    table: "Constituency",
            //    nullable: true);
            migrationBuilder.Sql(
                @"PRAGMA foreign_keys = 0;

                CREATE TABLE Constituencies_temp AS SELECT * FROM Constituency;

                DROP TABLE Constituency;

                CREATE TABLE Constituency (
                    Id                  INTEGER NOT NULL CONSTRAINT PK_Constituency PRIMARY KEY AUTOINCREMENT,
                    Name                NVARCHAR(512) NOT NULL,
                    AuthorityId         INTEGER,
                    ConstituencyTypeId  INTEGER,
                    FOREIGN KEY (ConstituencyTypeId) REFERENCES ConstituencyType(Id)
                );

                INSERT INTO Constituency
                (
                    Id, Name, AuthorityId
                )
                SELECT Id, Name, AuthorityId FROM Constituencies_temp;

                DROP TABLE Constituencies_temp;

                PRAGMA foreign_keys = 1;");


            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            //migrationBuilder.AddColumn<int>(
            //    name: "TitleId",
            //    table: "Member",
            //    nullable: true);
            migrationBuilder.Sql(
                @"PRAGMA foreign_keys = 0;                  
                
                DROP TABLE Member;

                CREATE TABLE Member (
                    Id              INTEGER NOT NULL CONSTRAINT PK_Member PRIMARY KEY AUTOINCREMENT,
                    TitleId         INTEGER,
                    Name            NVARCHAR(128) NOT NULL,
                    ConstituencyId  INTEGER NOT NULL,
                    PartyId         INTEGER NOT NULL,
                    TwitterId       INTEGER,
                    StartYear       INTEGER NOT NULL,
                    EndYear         INTEGER,
                    WhipSuspended   INTEGER NOT NULL,
                    FOREIGN KEY (TitleId) REFERENCES Title(Id),
                    FOREIGN KEY (ConstituencyId) REFERENCES Constituency(Id),
                    FOREIGN KEY (PartyId) REFERENCES Party(Id),
                    FOREIGN KEY (TwitterId) REFERENCES TwitterUser(Id)
                );

                INSERT INTO Member (Id, Name, ConstituencyId, PartyId, TwitterId, StartYear, EndYear, WhipSuspended)
                SELECT Id, Name, ConstituencyId, PartyId, TwitterId, StartYear, EndYear, WhipSuspended FROM Members_temp;

                PRAGMA foreign_keys = 1;");

            migrationBuilder.CreateIndex(
                name: "IX_Member_TitleId",
                table: "Member",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Constituency_ConstituencyTypeId",
                table: "Constituency",
                column: "ConstituencyTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Constituency_ConstituencyType_ConstituencyTypeId",
            //    table: "Constituency",
            //    column: "ConstituencyTypeId",
            //    principalTable: "ConstituencyType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Member_Title_TitleId",
            //    table: "Member",
            //    column: "TitleId",
            //    principalTable: "Title",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Constituency_ConstituencyType_ConstituencyTypeId",
                table: "Constituency");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Title_TitleId",
                table: "Member");

            migrationBuilder.DropTable(
                name: "ConstituencyType");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropIndex(
                name: "IX_Member_TitleId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Constituency_ConstituencyTypeId",
                table: "Constituency");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ConstituencyTypeId",
                table: "Constituency");
        }
    }
}
