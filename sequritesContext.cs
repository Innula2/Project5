using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project5
{
    public partial class sequritesContext : DbContext
    {
        public sequritesContext()
        {
        }

        public sequritesContext(DbContextOptions<sequritesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accountplan> Accountplans { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<Subaccount> Subaccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost; Port=5432;Database=sequrites;Username=postgres;Password=Inna2002");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accountplan>(entity =>
            {
                entity.ToTable("accountplan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("deal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agreement).HasColumnName("agreement");

                entity.Property(e => e.Commission)
                    .HasMaxLength(30)
                    .HasColumnName("commission");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");

                entity.Property(e => e.NumberDeal).HasColumnName("number_deal");

                entity.Property(e => e.OrderDeal).HasColumnName("order_deal");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Tiker)
                    .HasMaxLength(30)
                    .HasColumnName("tiker");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");

                entity.Property(e => e.Trader).HasColumnName("trader");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operation");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Dealid).HasColumnName("dealid");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Saldoinput).HasColumnName("saldoinput");

                entity.Property(e => e.Saldooutput).HasColumnName("saldooutput");

                entity.Property(e => e.Subaccountid).HasColumnName("subaccountid");

                entity.Property(e => e.Sum)
                    .HasMaxLength(30)
                    .HasColumnName("sum");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.HasOne(d => d.Deal)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Dealid)
                    .HasConstraintName("operation_dealid_fkey");

                entity.HasOne(d => d.Subaccount)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Subaccountid)
                    .HasConstraintName("operation_subaccountid_fkey");
            });

            modelBuilder.Entity<Subaccount>(entity =>
            {
                entity.ToTable("subaccount");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Accountplanid).HasColumnName("accountplanid");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.Accountplan)
                    .WithMany(p => p.Subaccounts)
                    .HasForeignKey(d => d.Accountplanid)
                    .HasConstraintName("subaccount_accountplanid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
