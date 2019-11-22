﻿using Microsoft.EntityFrameworkCore;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataModels.Sqlite
{
    public class MemberSqliteDBContext : DbContext
    {
        public DbSet<Authority> Authority { get; set; }
        public DbSet<Constituency> Constituency { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<TwitterUser> TwitterUser { get; set; }
        public DbSet<TwitterStats> TwitterStats { get; set; }
        public DbSet<TwitterFriends> TwitterFriends { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=MemberDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TwitterStats>().HasOne(ts => ts.TwitterUser).WithOne(tu => tu.TwitterStats).HasForeignKey<TwitterStats>(ts => ts.Id);

            modelBuilder.Entity<TwitterFriends>().HasOne(tf => tf.User).WithMany(tu => tu.TwitterFriendsUser).HasForeignKey(tf => tf.UserId);

            modelBuilder.Entity<TwitterFriends>().HasOne(tf => tf.Friend).WithMany(tu => tu.TwitterFriendsFriend).HasForeignKey(tf => tf.FriendId);

            modelBuilder.Entity<TwitterFriends>().HasKey(tf => new { tf.UserId, tf.FriendId });
        }
    }
}