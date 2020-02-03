using Handsoft.Prizes.App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handsoft.Prizes.App.Data
{
    public partial class PrizesContext : DbContext
    {
        public PrizesContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Draw> Draws { get; set; }
        public virtual DbSet<Help> Help { get; set; }
        public virtual DbSet<Prize> Prizes { get; set; }
        public virtual DbSet<Trackerservice> Trackerservices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Winner> Winners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Draw>(entity =>
            {
                entity.ToTable("draw");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Active).HasDefaultValueSql("'1'");

                entity.Property(e => e.ClientId).HasColumnType("int(11)");

                entity.Property(e => e.CodeLen).HasColumnType("int(11)");

                entity.Property(e => e.CountText)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entries)
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FakeId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GenerateCode).HasDefaultValueSql("'0'");

                entity.Property(e => e.InnactiveMessage)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InnactiveOutputNumber)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InputNumber)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Keyword)
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mode).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OutNumber)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OutputDisabled).HasDefaultValueSql("'0'");

                entity.Property(e => e.QueryMessage)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QueryOutNumber)
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sendsms)
                    .HasColumnName("sendsms")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Help>(entity =>
            {
                entity.ToTable("help");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.InNumber)
                    .HasColumnName("inNumber")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OutNumber)
                    .HasColumnName("outNumber")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Prize>(entity =>
            {
                entity.ToTable("prize");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.Property(e => e.DrawId).HasColumnType("int(11)");

                entity.Property(e => e.Given)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Image)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MessageOut)
                    .HasColumnType("varchar(450)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Trackerservice>(entity =>
            {
                entity.ToTable("trackerservice");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DrawId).HasColumnType("int(11)");

                entity.Property(e => e.Tid)
                    .HasColumnName("tid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Cellphone)
                    .HasName("cellphone");

                entity.HasIndex(e => e.Code)
                    .HasName("codeidx");

                entity.HasIndex(e => e.DrawId)
                    .HasName("drawidx");

                entity.HasIndex(e => e.ParticipantId)
                    .HasName("partidx");

                entity.HasIndex(e => e.Time)
                    .HasName("timeidx");

                entity.HasIndex(e => new { e.DrawId, e.Code })
                    .HasName("drawcodeidx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cellphone)
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DrawId).HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParticipantId)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PersonId)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RegistrationType).HasColumnType("int(11)");

                entity.Property(e => e.Sended).HasDefaultValueSql("'0'");

                entity.Property(e => e.Telco)
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.WinSend).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Winner>(entity =>
            {
                entity.ToTable("winner");

                entity.HasIndex(e => e.PrizeId)
                    .HasName("prizeidx");

                entity.HasIndex(e => e.UserId)
                    .HasName("useridx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PrizeId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Wtime)
                    .HasColumnName("WTime")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}