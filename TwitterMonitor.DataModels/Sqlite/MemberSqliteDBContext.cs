using Microsoft.EntityFrameworkCore;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataModels.Sqlite
{
    public class MemberSqliteDBContext : DbContext
    {
        // Lookups
        public DbSet<Gender> Genders { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<AreaType> AreaTypes { get; set; }
        public DbSet<ConstituencyType> ConstituencyTypes { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<ElectionType> ElectionTypes { get; set; }
        public DbSet<CommitteeType> CommitteeTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<GovernmentRank> GovernmentRanks { get; set; }
        public DbSet<GovernmentPost> GovernmentPosts { get; set; }
        public DbSet<OppositionRank> OppositionRanks { get; set; }
        public DbSet<OppositionPost> OppositionPosts { get; set; }
        public DbSet<ParliamentaryRank> ParliamentaryRanks { get; set; }
        public DbSet<ParliamentaryPost> ParliamentaryPosts { get; set; }


        // Data
        public DbSet<Area> Areas { get; set; }
        public DbSet<Constituency> Constituencies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Committee> Committees { get; set; }


        // Joins
        public DbSet<ConstituencyArea> ConstituencyAreas { get; set; }
        public DbSet<ConstituencyMember> ConstituencyMembers { get; set; }
        public DbSet<HouseMember> HouseMembers { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<GovernmentPostMember> GovernmentPostMembers { get; set; }
        public DbSet<GovernmentPostDepartment> GovernmentPostDepartments { get; set; }
        public DbSet<OppositionPostMember> OppositionPostMembers { get; set; }
        public DbSet<OppositionPostDepartment> OppositionPostDepartments { get; set; }
        public DbSet<ParliamentaryPostMember> ParliamentaryPostMembers { get; set; }



        public DbSet<Events> Events { get; set; }

        public DbSet<TwitterUser> TwitterUsers { get; set; }
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
