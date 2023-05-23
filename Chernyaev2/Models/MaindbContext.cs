using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chernyaev2.Models;

public partial class MaindbContext : DbContext
{
    public MaindbContext()
    {
    }

    public MaindbContext(DbContextOptions<MaindbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;user=root;database=maindb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("records");

            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.Visit).HasMaxLength(100);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staffs");

            entity.HasIndex(e => e.Login, "Login_UNIQUE").IsUnique();

            entity.Property(e => e.Depart).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
