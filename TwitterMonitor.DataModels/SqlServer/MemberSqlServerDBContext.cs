using System;
using Microsoft.EntityFrameworkCore;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataModels.SqlServer
{
    public partial class MemberSqlServerDBContext : DbContext
    {
        public MemberSqlServerDBContext()
        {
        }

        public MemberSqlServerDBContext(DbContextOptions<MemberSqlServerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<Constituency> Constituency { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<TwitterFriends> TwitterFriends { get; set; }
        public virtual DbSet<TwitterStats> TwitterStats { get; set; }
        public virtual DbSet<TwitterUser> TwitterUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=MemberDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authority>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Authority)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authority_Region");
            });

            modelBuilder.Entity<Constituency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Constituency)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_Constituency_Authority");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Happened).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.ConstituencyId);

                entity.HasIndex(e => e.PartyId);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Constituency)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.ConstituencyId);

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.PartyId);

                entity.HasOne(d => d.Twitter)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.TwitterId)
                    .HasConstraintName("FK_Member_TwitterUser");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_Country");
            });

            modelBuilder.Entity<TwitterFriends>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendId });

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.TwitterFriendsFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TwitterFriends_TwitterUser1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TwitterFriendsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TwitterFriends_TwitterUser");
            });

            modelBuilder.Entity<TwitterStats>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TwitterStats)
                    .HasForeignKey<TwitterStats>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TwitterStats_TwitterUser");
            });

            modelBuilder.Entity<TwitterUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ScreenName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
