using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ktpOtoWithCore.Models;

public partial class KtpCase1Context : DbContext
{
    public KtpCase1Context()
    {
    }

    public KtpCase1Context(DbContextOptions<KtpCase1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Kitaplar> Kitaplars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CGDTBSJ\\MSSQLSERVER5;Database=ktp_case1;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kategori__3213E83F0886AD79");

            entity.ToTable("Kategoriler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KategoriAd)
                .HasMaxLength(50)
                .HasColumnName("kategoriAd");
        });

        modelBuilder.Entity<Kitaplar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kitaplar__3213E83F958C7B6D");

            entity.ToTable("Kitaplar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriID");
            entity.Property(e => e.KitapAd)
                .HasMaxLength(150)
                .HasColumnName("kitapAd");
            entity.Property(e => e.SayfaSayisi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sayfaSayisi");
            entity.Property(e => e.Yazar)
                .HasMaxLength(150)
                .HasColumnName("yazar");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Kitaplars)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__Kitaplar__sayfaS__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
