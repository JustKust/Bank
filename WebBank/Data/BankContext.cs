using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebBank.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBank.Data
{
    public partial class BankContext : DbContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Deposit> Deposit { get; set; }
        public virtual DbSet<Depositor> Depositor { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Bank.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExchangeRate).HasColumnType("FLOAT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddCond)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (60)");

                entity.Property(e => e.InterestRate).HasColumnType("FLOAT");

                entity.Property(e => e.MinDepAmount).HasColumnType("INT");

                entity.Property(e => e.MinDepTern)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.Deposit)
                    .HasForeignKey(d => d.CurId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Depositor>(entity =>
            {
                entity.HasKey(e => e.DepostorId);

                entity.Property(e => e.DepostorId)
                    .HasColumnName("DepostorID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("VARCHAR (100)");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepRafMark)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.DeposDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.EmId)
                    .HasColumnName("EmID")
                    .HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("VARCHAR (60)");

                entity.Property(e => e.PassData)
                    .IsRequired()
                    .HasColumnType("VARCHAR (20)");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnType("VARCHAR (11)");

                entity.Property(e => e.RefundDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.SummAm).HasColumnType("INT");

                entity.Property(e => e.SummRef).HasColumnType("INT");

                entity.HasOne(d => d.Em)
                    .WithMany(p => p.Depositor)
                    .HasForeignKey(d => d.EmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmId);

                entity.Property(e => e.EmId)
                    .HasColumnName("EmID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (100)");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full_Name")
                    .HasColumnType("NVARCHAR (60)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (1)");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (11)");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.PosName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (60)");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (200)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (200)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
