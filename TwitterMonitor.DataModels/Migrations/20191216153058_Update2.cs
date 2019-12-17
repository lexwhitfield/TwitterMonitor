using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterMonitor.DataModels.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Members_Houses_HouseId",
            //    table: "Members");

            //migrationBuilder.DropIndex(
            //    name: "IX_Members_HouseId",
            //    table: "Members");

            //migrationBuilder.DropColumn(
            //    name: "HouseId",
            //    table: "Members");

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TwitterUserId = table.Column<long>(nullable: false),
                    FullText = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    InReplyToScreenName = table.Column<string>(nullable: true),
                    InReplyToStatusId = table.Column<long>(nullable: true),
                    InReplyToUserId = table.Column<long>(nullable: true),
                    IsRetweet = table.Column<bool>(nullable: false),
                    QuotedStatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_TwitterUsers_TwitterUserId",
                        column: x => x.TwitterUserId,
                        principalTable: "TwitterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMentions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScreenName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMentions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TweetHashtags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TweetId = table.Column<long>(nullable: false),
                    HashtagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetHashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetHashtags_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TweetHashtags_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TweetUrls",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TweetId = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetUrls_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TweetUserMentions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TweetId = table.Column<long>(nullable: false),
                    UserMentionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetUserMentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetUserMentions_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TweetUserMentions_UserMentions_UserMentionId",
                        column: x => x.UserMentionId,
                        principalTable: "UserMentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TweetHashtags_HashtagId",
                table: "TweetHashtags",
                column: "HashtagId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetHashtags_TweetId",
                table: "TweetHashtags",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_TwitterUserId",
                table: "Tweets",
                column: "TwitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetUrls_TweetId",
                table: "TweetUrls",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetUserMentions_TweetId",
                table: "TweetUserMentions",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetUserMentions_UserMentionId",
                table: "TweetUserMentions",
                column: "UserMentionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetHashtags");

            migrationBuilder.DropTable(
                name: "TweetUrls");

            migrationBuilder.DropTable(
                name: "TweetUserMentions");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "UserMentions");

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Members",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_HouseId",
                table: "Members",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Houses_HouseId",
                table: "Members",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
