using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem_WebApi_MidExam.Models;

public partial class AssetManagementSystemDbWebApiContext : DbContext
{
    public AssetManagementSystemDbWebApiContext()
    {
    }

    public AssetManagementSystemDbWebApiContext(DbContextOptions<AssetManagementSystemDbWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetDefinition> AssetDefinitions { get; set; }

    public virtual DbSet<AssetMaster> AssetMasters { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }
/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = AssetManagementSystem_db_WebApi; Integrated Security = True; Trusted_Connection=True;TrustServerCertificate=True");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetDefinition>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PK__Asset_De__CAA4A6275BF1DDBA");

            entity.ToTable("Asset_Definition");

            entity.Property(e => e.AdId).HasColumnName("ad_id");
            entity.Property(e => e.AdClass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ad_class");
            entity.Property(e => e.AdName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ad_name");
            entity.Property(e => e.AdTypeId).HasColumnName("ad_type_id");

            entity.HasOne(d => d.AdType).WithMany(p => p.AssetDefinitions)
                .HasForeignKey(d => d.AdTypeId)
                .HasConstraintName("FK__Asset_Def__ad_ty__440B1D61");
        });

        modelBuilder.Entity<AssetMaster>(entity =>
        {
            entity.HasKey(e => e.AmId).HasName("PK__Asset_Ma__B95A8ED0FF363984");

            entity.ToTable("Asset_Master");

            entity.Property(e => e.AmId).HasColumnName("am_id");
            entity.Property(e => e.AmAdId).HasColumnName("am_ad_id");
            entity.Property(e => e.AmAtypeId).HasColumnName("am_atype_id");
            entity.Property(e => e.AmFrom).HasColumnName("am_from");
            entity.Property(e => e.AmMakeId).HasColumnName("am_make_id");
            entity.Property(e => e.AmModel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("am_model");
            entity.Property(e => e.AmMyyear).HasColumnName("am_myyear");
            entity.Property(e => e.AmPdate).HasColumnName("am_pdate");
            entity.Property(e => e.AmSnumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("am_snumber");
            entity.Property(e => e.AmTo).HasColumnName("am_to");
            entity.Property(e => e.AmWarranty).HasColumnName("am_warranty");

            entity.HasOne(d => d.AmAd).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.AmAdId)
                .HasConstraintName("FK__Asset_Mas__am_ad__52593CB8");

            entity.HasOne(d => d.AmAtype).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.AmAtypeId)
                .HasConstraintName("FK__Asset_Mas__am_at__5070F446");

            entity.HasOne(d => d.AmMake).WithMany(p => p.AssetMasters)
                .HasForeignKey(d => d.AmMakeId)
                .HasConstraintName("FK__Asset_Mas__am_ma__5165187F");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasKey(e => e.AtId).HasName("PK__Asset_Ty__61F85988B5B744A6");

            entity.ToTable("Asset_Type");

            entity.Property(e => e.AtId).HasColumnName("at_id");
            entity.Property(e => e.AtName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("at_name");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LId).HasName("PK__Login__A7C7B6F863511373");

            entity.ToTable("Login");

            entity.Property(e => e.LId).HasColumnName("l_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usertype)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PdId).HasName("PK__Purchase__F7562CCF2D2F9098");

            entity.ToTable("Purchase_Order");

            entity.Property(e => e.PdId).HasColumnName("pd_id");
            entity.Property(e => e.PdAdId).HasColumnName("pd_ad_id");
            entity.Property(e => e.PdDate).HasColumnName("pd_date");
            entity.Property(e => e.PdDdate).HasColumnName("pd_ddate");
            entity.Property(e => e.PdOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pd_order_no");
            entity.Property(e => e.PdQty).HasColumnName("pd_qty");
            entity.Property(e => e.PdStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pd_status");
            entity.Property(e => e.PdTypeId).HasColumnName("pd_type_id");
            entity.Property(e => e.PdVendorId).HasColumnName("pd_vendor_id");

            entity.HasOne(d => d.PdAd).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.PdAdId)
                .HasConstraintName("FK__PurchaseO__pd_ad__4AB81AF0");

            entity.HasOne(d => d.PdType).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.PdTypeId)
                .HasConstraintName("FK__PurchaseO__pd_ty__4CA06362");

            entity.HasOne(d => d.PdVendor).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.PdVendorId)
                .HasConstraintName("FK__PurchaseO__pd_ve__4BAC3F29");
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__UserRegi__B51D3DEABC5AB8B7");

            entity.ToTable("UserRegistration");

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LId).HasColumnName("l_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.LIdNavigation).WithMany(p => p.UserRegistrations)
                .HasForeignKey(d => d.LId)
                .HasConstraintName("FK__UserRegist__l_id__3F466844");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VdId).HasName("PK__Vendor__277BC6C0F62E5BCD");

            entity.ToTable("Vendor");

            entity.Property(e => e.VdId).HasColumnName("vd_id");
            entity.Property(e => e.VdAddr)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("vd_addr");
            entity.Property(e => e.VdAtypeId).HasColumnName("vd_atype_id");
            entity.Property(e => e.VdFrom).HasColumnName("vd_from");
            entity.Property(e => e.VdName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vd_name");
            entity.Property(e => e.VdTo).HasColumnName("vd_to");
            entity.Property(e => e.VdType)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vd_type");

            entity.HasOne(d => d.VdAtype).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.VdAtypeId)
                .HasConstraintName("FK__Vendor__vd_atype__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
