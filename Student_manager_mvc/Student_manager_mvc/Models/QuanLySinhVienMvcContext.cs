using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student_manager_mvc.Models;

public partial class QuanLySinhVienMvcContext : DbContext
{
    public QuanLySinhVienMvcContext()
    {
    }

    public QuanLySinhVienMvcContext(DbContextOptions<QuanLySinhVienMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DangKyHoc> DangKyHocs { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q0PAQT9D\\SANGHOCSQL;Initial Catalog=QuanLySinhVien_mvc;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DangKyHoc>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__DangKyHo__7F6877FBFE10C9E9");

            entity.ToTable("DangKyHoc");

            entity.Property(e => e.EnrollmentId)
                .HasMaxLength(10)
                .HasColumnName("EnrollmentID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .HasColumnName("ClassID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(10)
                .HasColumnName("SubjectID");

            entity.HasOne(d => d.Class).WithMany(p => p.DangKyHocs)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__DangKyHoc__Class__5070F446");

            entity.HasOne(d => d.Student).WithMany(p => p.DangKyHocs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__DangKyHoc__Stude__4F7CD00D");

            entity.HasOne(d => d.Subject).WithMany(p => p.DangKyHocs)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__DangKyHoc__Subje__5165187F");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__LopHoc__CB1927A0DA687C53");

            entity.ToTable("LopHoc");

            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Teacher).HasMaxLength(100);
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__MonHoc__AC1BA388A3EF52E4");

            entity.ToTable("MonHoc");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(10)
                .HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__SinhVien__32C52A79C276ECBB");

            entity.ToTable("SinhVien");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(255);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__TaiKhoan__349DA5860D83CCFE");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
