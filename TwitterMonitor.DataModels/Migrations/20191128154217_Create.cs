using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstituencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    Minister = table.Column<bool>(nullable: false),
                    Secretary = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Happened = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MinisterialRank = table.Column<int>(nullable: true),
                    StatsRank = table.Column<string>(nullable: true),
                    ClerksRank = table.Column<string>(nullable: true),
                    OrderRank = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OppositionRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MinisterialRank = table.Column<int>(nullable: true),
                    StatsRank = table.Column<string>(nullable: true),
                    ClerksRank = table.Column<string>(nullable: true),
                    OrderRank = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppositionRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParliamentaryRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParliamentaryRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Abbr = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    TextColour = table.Column<string>(nullable: true),
                    IsCommons = table.Column<bool>(nullable: false),
                    IsLords = table.Column<bool>(nullable: false),
                    OldDisId = table.Column<int>(nullable: true),
                    HoLMainParty = table.Column<bool>(nullable: false),
                    HoLOrder = table.Column<int>(nullable: true),
                    HoLIsSpiritualSide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TwitterUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScreenName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    OnsId = table.Column<string>(nullable: true),
                    AreaTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_AreaTypes_AreaTypeId",
                        column: x => x.AreaTypeId,
                        principalTable: "AreaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommitteeTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentCommitteeId = table.Column<int>(nullable: true),
                    DateLordsAppointed = table.Column<DateTime>(nullable: true),
                    DateCommonsAppointed = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CreatedFromCommitteeId = table.Column<int>(nullable: true),
                    IsCommons = table.Column<bool>(nullable: false),
                    IsLords = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Committees_CommitteeTypes_CommitteeTypeId",
                        column: x => x.CommitteeTypeId,
                        principalTable: "CommitteeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Constituencies",
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
                    table.PrimaryKey("PK_Constituencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Constituencies_ConstituencyTypes_ConstituencyTypeId",
                        column: x => x.ConstituencyTypeId,
                        principalTable: "ConstituencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElectionTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ElectionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elections_ElectionTypes_ElectionTypeId",
                        column: x => x.ElectionTypeId,
                        principalTable: "ElectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    GovernmentRankId = table.Column<int>(nullable: false),
                    Promoted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    HansardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentPosts_GovernmentRanks_GovernmentRankId",
                        column: x => x.GovernmentRankId,
                        principalTable: "GovernmentRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OppositionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    OppositionRankId = table.Column<int>(nullable: false),
                    Promoted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    HansardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppositionPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OppositionPosts_OppositionRanks_OppositionRankId",
                        column: x => x.OppositionRankId,
                        principalTable: "OppositionRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParliamentaryPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ParliamentaryRankId = table.Column<int>(nullable: true),
                    ExcludeFromCount = table.Column<bool>(nullable: false),
                    Promoted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsCommons = table.Column<bool>(nullable: false),
                    IsLords = table.Column<bool>(nullable: false),
                    HansardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParliamentaryPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParliamentaryPosts_ParliamentaryRanks_ParliamentaryRankId",
                        column: x => x.ParliamentaryRankId,
                        principalTable: "ParliamentaryRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DodsId = table.Column<int>(nullable: true),
                    PimsId = table.Column<int>(nullable: true),
                    ClerksId = table.Column<int>(nullable: true),
                    TitleId = table.Column<int>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    HouseId = table.Column<int>(nullable: true),
                    TwitterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_TwitterUsers_TwitterUserId",
                        column: x => x.TwitterUserId,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TwitterFriends",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    FriendId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterFriends", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_TwitterFriends_TwitterUsers_FriendId",
                        column: x => x.FriendId,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TwitterFriends_TwitterUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TwitterStats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    FollowerCount = table.Column<int>(nullable: false),
                    FriendCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwitterStats_TwitterUsers_Id",
                        column: x => x.Id,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstituencyAreas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConstituencyId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstituencyAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituencyAreas_Constituencies_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "Constituencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentPostDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GovernmentPostId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentPostDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentPostDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GovernmentPostDepartments_GovernmentPosts_GovernmentPostId",
                        column: x => x.GovernmentPostId,
                        principalTable: "GovernmentPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OppositionPostDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OppositionPostId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppositionPostDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OppositionPostDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OppositionPostDepartments_OppositionPosts_OppositionPostId",
                        column: x => x.OppositionPostId,
                        principalTable: "OppositionPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommitteeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    EndNote = table.Column<string>(nullable: true),
                    IsExOfficio = table.Column<bool>(nullable: false),
                    IsAlternate = table.Column<bool>(nullable: false),
                    IsCoOpted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeMembers_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstituencyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConstituencyId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ElectionId = table.Column<int>(nullable: false),
                    EndReason = table.Column<string>(nullable: true),
                    EntryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstituencyMembers_Constituencies_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "Constituencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituencyMembers_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituencyMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentPostMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GovernmentPostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentPostMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentPostMembers_GovernmentPosts_GovernmentPostId",
                        column: x => x.GovernmentPostId,
                        principalTable: "GovernmentPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GovernmentPostMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(nullable: false),
                    HouseId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    EndReason = table.Column<string>(nullable: true),
                    EndNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseMembers_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OppositionPostMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GovernmentPostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    OppositionPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppositionPostMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OppositionPostMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OppositionPostMembers_OppositionPosts_OppositionPostId",
                        column: x => x.OppositionPostId,
                        principalTable: "OppositionPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParliamentaryPostMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParliamentaryPostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParliamentaryPostMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParliamentaryPostMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParliamentaryPostMembers_ParliamentaryPosts_ParliamentaryPostId",
                        column: x => x.ParliamentaryPostId,
                        principalTable: "ParliamentaryPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AreaTypeId",
                table: "Areas",
                column: "AreaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMembers_CommitteeId",
                table: "CommitteeMembers",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMembers_MemberId",
                table: "CommitteeMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_CommitteeTypeId",
                table: "Committees",
                column: "CommitteeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Constituencies_ConstituencyTypeId",
                table: "Constituencies",
                column: "ConstituencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyAreas_AreaId",
                table: "ConstituencyAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyAreas_ConstituencyId",
                table: "ConstituencyAreas",
                column: "ConstituencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyMembers_ConstituencyId",
                table: "ConstituencyMembers",
                column: "ConstituencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyMembers_ElectionId",
                table: "ConstituencyMembers",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituencyMembers_MemberId",
                table: "ConstituencyMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_ElectionTypeId",
                table: "Elections",
                column: "ElectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentPostDepartments_DepartmentId",
                table: "GovernmentPostDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentPostDepartments_GovernmentPostId",
                table: "GovernmentPostDepartments",
                column: "GovernmentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentPostMembers_GovernmentPostId",
                table: "GovernmentPostMembers",
                column: "GovernmentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentPostMembers_MemberId",
                table: "GovernmentPostMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentPosts_GovernmentRankId",
                table: "GovernmentPosts",
                column: "GovernmentRankId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseMembers_HouseId",
                table: "HouseMembers",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseMembers_MemberId",
                table: "HouseMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GenderId",
                table: "Members",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_HouseId",
                table: "Members",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TitleId",
                table: "Members",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TwitterUserId",
                table: "Members",
                column: "TwitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OppositionPostDepartments_DepartmentId",
                table: "OppositionPostDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OppositionPostDepartments_OppositionPostId",
                table: "OppositionPostDepartments",
                column: "OppositionPostId");

            migrationBuilder.CreateIndex(
                name: "IX_OppositionPostMembers_MemberId",
                table: "OppositionPostMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OppositionPostMembers_OppositionPostId",
                table: "OppositionPostMembers",
                column: "OppositionPostId");

            migrationBuilder.CreateIndex(
                name: "IX_OppositionPosts_OppositionRankId",
                table: "OppositionPosts",
                column: "OppositionRankId");

            migrationBuilder.CreateIndex(
                name: "IX_ParliamentaryPostMembers_MemberId",
                table: "ParliamentaryPostMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ParliamentaryPostMembers_ParliamentaryPostId",
                table: "ParliamentaryPostMembers",
                column: "ParliamentaryPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ParliamentaryPosts_ParliamentaryRankId",
                table: "ParliamentaryPosts",
                column: "ParliamentaryRankId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitterFriends_FriendId",
                table: "TwitterFriends",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeMembers");

            migrationBuilder.DropTable(
                name: "ConstituencyAreas");

            migrationBuilder.DropTable(
                name: "ConstituencyMembers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GovernmentPostDepartments");

            migrationBuilder.DropTable(
                name: "GovernmentPostMembers");

            migrationBuilder.DropTable(
                name: "HouseMembers");

            migrationBuilder.DropTable(
                name: "OppositionPostDepartments");

            migrationBuilder.DropTable(
                name: "OppositionPostMembers");

            migrationBuilder.DropTable(
                name: "ParliamentaryPostMembers");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "TwitterFriends");

            migrationBuilder.DropTable(
                name: "TwitterStats");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Constituencies");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "GovernmentPosts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "OppositionPosts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ParliamentaryPosts");

            migrationBuilder.DropTable(
                name: "CommitteeTypes");

            migrationBuilder.DropTable(
                name: "AreaTypes");

            migrationBuilder.DropTable(
                name: "ConstituencyTypes");

            migrationBuilder.DropTable(
                name: "ElectionTypes");

            migrationBuilder.DropTable(
                name: "GovernmentRanks");

            migrationBuilder.DropTable(
                name: "OppositionRanks");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "TwitterUsers");

            migrationBuilder.DropTable(
                name: "ParliamentaryRanks");
        }
    }
}
