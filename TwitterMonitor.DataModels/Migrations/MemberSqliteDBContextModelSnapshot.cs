﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterMonitor.DataModels.Sqlite;

namespace TwitterMonitor.DataModels.Migrations
{
    [DbContext(typeof(MemberSqliteDBContext))]
    partial class MemberSqliteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OnsId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AreaTypeId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.AreaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AreaType");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Authority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Authority");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Constituency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConstituencyTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorityId");

                    b.HasIndex("ConstituencyTypeId");

                    b.ToTable("Constituency");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.ConstituencyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConstituencyType");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Happened")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConstituencyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PartyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartYear")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TitleId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TwitterId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WhipSuspended")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConstituencyId");

                    b.HasIndex("PartyId");

                    b.HasIndex("TitleId");

                    b.HasIndex("TwitterId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Party");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.TwitterFriends", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FriendId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "FriendId");

                    b.HasIndex("FriendId");

                    b.ToTable("TwitterFriends");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.TwitterStats", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowerCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FriendCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TwitterStats");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.TwitterUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScreenName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TwitterUser");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Area", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.AreaType", "AreaType")
                        .WithMany()
                        .HasForeignKey("AreaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Authority", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Region", "Region")
                        .WithMany("Authority")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Constituency", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Authority", "Authority")
                        .WithMany("Constituency")
                        .HasForeignKey("AuthorityId");

                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.ConstituencyType", "ConstituencyType")
                        .WithMany()
                        .HasForeignKey("ConstituencyTypeId");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Member", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Constituency", "Constituency")
                        .WithMany("Member")
                        .HasForeignKey("ConstituencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Party", "Party")
                        .WithMany("Member")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");

                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.TwitterUser", "Twitter")
                        .WithMany("Member")
                        .HasForeignKey("TwitterId");
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.Region", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.Country", "Country")
                        .WithMany("Region")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.TwitterFriends", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.TwitterUser", "Friend")
                        .WithMany("TwitterFriendsFriend")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.TwitterUser", "User")
                        .WithMany("TwitterFriendsUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterMonitor.DataModels.Sqlite.Models.TwitterStats", b =>
                {
                    b.HasOne("TwitterMonitor.DataModels.Sqlite.Models.TwitterUser", "TwitterUser")
                        .WithOne("TwitterStats")
                        .HasForeignKey("TwitterMonitor.DataModels.Sqlite.Models.TwitterStats", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
