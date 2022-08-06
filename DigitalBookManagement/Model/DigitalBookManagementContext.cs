﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalBookManagement.Model
{
    public partial class DigitalBookManagementContext : DbContext
    {
        public DigitalBookManagementContext()
        {
        }

        public DigitalBookManagementContext(DbContextOptions<DigitalBookManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET664;Initial Catalog=DigitalBookManagement;Persist Security Info=True;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("bookTitle");

                entity.Property(e => e.Category)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedDate");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("publisher");

                entity.Property(e => e.PublistDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publistDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__book__userId__276EDEB3");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__payment__bookId__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__payment__userId__2B3F6F97");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__CB9A1CFFB8CB5B8A");

                entity.ToTable("userDetails");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
