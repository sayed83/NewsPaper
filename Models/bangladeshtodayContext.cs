using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BangladeshToday.Models;

namespace BangladeshToday.Models
{
    public partial class bangladeshtodayContext : DbContext
    {
        public virtual DbSet<Allvideo> Allvideo { get; set; }
        public virtual DbSet<Newsinfo> Newsinfo { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<Videonews> Videonews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=SQL5040.site4now.net;Initial Catalog=DB_A429DB_morningbelldb;User Id=DB_A429DB_morningbelldb_admin;Password=123456m@M;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allvideo>(entity =>
            {
                entity.HasKey(e => new { e.VideoId, e.VideoSerial });

                entity.ToTable("allvideo");

                entity.Property(e => e.VideoId).HasColumnName("videoId");

                entity.Property(e => e.VideoSerial)
                    .HasColumnName("videoSerial")
                    .HasMaxLength(200);

                entity.Property(e => e.VideoPath).HasColumnName("videoPath");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Allvideo)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__allvideo__videoI__5441852A");
            });

            modelBuilder.Entity<Newsinfo>(entity =>
            {
                entity.HasKey(e => e.Newsserial);

                entity.ToTable("newsinfo");

                entity.Property(e => e.Newsserial).HasColumnName("newsserial");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(200);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(200);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("keyword");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.CaptionPicture).HasColumnName("captionPicture");
                entity.Property(e => e.Editor).HasColumnName("editor");
                entity.Property(e => e.FeatureNews).HasColumnName("featureNews");
                entity.Property(e => e.HotNews).HasColumnName("hotNews");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.SlideShow).HasColumnName("slideShow");
                entity.Property(e => e.SubFeatureNews).HasColumnName("subFeatureNews")
                 .HasMaxLength(100);

            });


            modelBuilder.Entity<AdsDetails>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("adsdetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(200);
                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("companyAddress")
                    .HasMaxLength(500);
                entity.Property(e => e.Companyurl)
                    .HasColumnName("companyurl")
                    .HasMaxLength(500);
                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasMaxLength(500);
                entity.Property(e => e.Title)
                    .HasColumnName("title");
                entity.Property(e => e.Description)
                    .HasColumnName("description");
                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate");
                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate");
                entity.Property(e => e.DailyRate)
                    .HasColumnName("dailyRate");
                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice");

            });

                modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(200);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Videonews>(entity =>
            {
                entity.ToTable("videonews");

                entity.Property(e => e.VideoNewsId).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(200);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("keyword");

                entity.Property(e => e.Path).HasColumnName("path");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });
        }

        public DbSet<BangladeshToday.Models.AdsDetails> AdsDetails { get; set; }
    }
}
