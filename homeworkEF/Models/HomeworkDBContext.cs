using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace homeworkEF.Models
{
    public partial class HomeworkDBContext : DbContext
    {
        public HomeworkDBContext()
        {
        }

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblFood> TblFoods { get; set; } = null!;
        public virtual DbSet<TblFoodOrder> TblFoodOrders { get; set; } = null!;
        public virtual DbSet<TblHero> TblHeroes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=HomeworkDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("TblCustomer");

                entity.Property(e => e.Money).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.ToTable("TblFood");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Style)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblFoodOrder>(entity =>
            {
                entity.ToTable("TblFoodOrder");

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.PaidDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblHero>(entity =>
            {
                entity.ToTable("TblHero");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
