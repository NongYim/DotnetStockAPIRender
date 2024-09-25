using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;///ช่วยในการทำ login logout register
using Microsoft.EntityFrameworkCore;

namespace DotnetStockAPI.Models;

public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>//IdentityDbContext มันจะได้ 7ตารางการทำ jwt เพิ่มมาด้วย // DbContext  ถ้าใช้ DbContext มันจะมีตารางเท่ากับโมเดล
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<product> product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //เพิ่มส่วนนี้เข้าไป เพื่อที่ว่าครั้งแรกไม่ถูกเจน พวกตาราง jwt จะไม่แจ้ง warning
        base.OnModelCreating(modelBuilder);




        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.categoryid).HasName("PK__category__23CDE590E0D8E1A2");
   
            entity.ToTable("category");
            entity.Property(e => e.categoryname)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.productid).HasName("PK__product__2D172D32EE51A3CF");
            entity.ToTable("product");
            entity.Property(e => e.createddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.modifieddate).HasColumnType("datetime");
            entity.Property(e => e.productname)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.productpicture)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.unitprice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
