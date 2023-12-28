using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLD_BE.Models;

public partial class QldsvContext : DbContext
{
    public QldsvContext()
    {
    }

    public QldsvContext(DbContextOptions<QldsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<HocPhan> HocPhans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<NamHoc> NamHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R9TUIAE\\SQLEXPRESS;Initial Catalog=QLDSV;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => new { e.Login, e.Pass }).HasName("PK_Account_1");

            entity.ToTable("Account");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Pass).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.GioiTinh).HasMaxLength(20);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.PhanQuyen).HasMaxLength(10);
            entity.Property(e => e.Phone).HasMaxLength(11);
        });

        modelBuilder.Entity<Diem>(entity =>
        {
            entity.HasKey(e => e.Idd);

            entity.ToTable("Diem");

            entity.Property(e => e.Idd).HasColumnName("IDD");
            entity.Property(e => e.DiemCc).HasColumnName("DiemCC");
            entity.Property(e => e.DiemTb).HasColumnName("DiemTB");
            entity.Property(e => e.Idh).HasColumnName("IDH");
            entity.Property(e => e.Idn).HasColumnName("IDN");
            entity.Property(e => e.Idsv).HasColumnName("IDSV");

            entity.HasOne(d => d.IdhNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Idh)
                .HasConstraintName("FK_Diem_HocPhan");

            entity.HasOne(d => d.IdnNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Idn)
                .HasConstraintName("FK_Diem_NamHoc");

            entity.HasOne(d => d.IdsvNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Idsv)
                .HasConstraintName("FK_Diem_SinhVien");
        });

        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.HasKey(e => e.Idgv);

            entity.ToTable("GiaoVien");

            entity.Property(e => e.Idgv).HasColumnName("IDGV");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.TenGv)
                .HasMaxLength(100)
                .HasColumnName("TenGV");
        });

        modelBuilder.Entity<HocPhan>(entity =>
        {
            entity.HasKey(e => e.Idh);

            entity.ToTable("HocPhan");

            entity.Property(e => e.Idh).HasColumnName("IDH");
            entity.Property(e => e.Idgv).HasColumnName("IDGV");
            entity.Property(e => e.SoTc).HasColumnName("SoTC");
            entity.Property(e => e.TenHp)
                .HasMaxLength(50)
                .HasColumnName("TenHP");

            entity.HasOne(d => d.IdgvNavigation).WithMany(p => p.HocPhans)
                .HasForeignKey(d => d.Idgv)
                .HasConstraintName("FK_HocPhan_GiaoVien");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Idk);

            entity.ToTable("Khoa");

            entity.Property(e => e.Idk).HasColumnName("IDK");
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Idl);

            entity.ToTable("Lop");

            entity.Property(e => e.Idl).HasColumnName("IDL");
            entity.Property(e => e.Idk).HasColumnName("IDK");
            entity.Property(e => e.TenLop).HasMaxLength(50);

            entity.HasOne(d => d.IdkNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.Idk)
                .HasConstraintName("FK_Lop_Khoa");
        });

        modelBuilder.Entity<NamHoc>(entity =>
        {
            entity.HasKey(e => e.Idn);

            entity.ToTable("NamHoc");

            entity.Property(e => e.Idn).HasColumnName("IDN");
            entity.Property(e => e.NamHoc1).HasColumnName("NamHoc");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Idsv);

            entity.ToTable("SinhVien");

            entity.Property(e => e.Idsv).HasColumnName("IDSV");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.GioiTinh).HasMaxLength(20);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Idl).HasColumnName("IDL");

            entity.HasOne(d => d.IdlNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Idl)
                .HasConstraintName("FK_SinhVien_Lop");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
