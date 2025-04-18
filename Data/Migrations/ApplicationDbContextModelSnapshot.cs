﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUP_INV1._0.Data;

#nullable disable

namespace SUP_INV1._0.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SUP_INV1._0.Models.FARMPRODUCTSPREPAREDRECORD", b =>
                {
                    b.Property<int>("FPRecIDPREP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FPRecIDPREP"));

                    b.Property<DateTime>("FPRecDateSoldPREP")
                        .HasColumnType("datetime2");

                    b.Property<string>("FPRecDescriptionPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FPRecNamePREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FPRecSoldAmountPREP")
                        .HasColumnType("float");

                    b.Property<double>("FPRecStockInPricePREP")
                        .HasColumnType("float");

                    b.Property<double>("FPRecStockOutPricePREP")
                        .HasColumnType("float");

                    b.Property<string>("FPRecSupplierEmailPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemIDPREP")
                        .HasColumnType("int");

                    b.HasKey("FPRecIDPREP");

                    b.ToTable("FARMPRODUCTSPREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.FARMPRODUCTSSALESRECORD", b =>
                {
                    b.Property<int>("FPRecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FPRecID"));

                    b.Property<DateTime>("FPRecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("FPRecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FPRecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FPRecSoldAmount")
                        .HasColumnType("float");

                    b.Property<double>("FPRecStockInPrice")
                        .HasColumnType("float");

                    b.Property<double>("FPRecStockOutPrice")
                        .HasColumnType("float");

                    b.Property<string>("FPRecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.HasKey("FPRecID");

                    b.ToTable("FARMPRODUCTSSALESRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.FarmProducts", b =>
                {
                    b.Property<int>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FID"));

                    b.Property<double>("Amount_In_Kg")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maximum_Shelf_Life_Days")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Stock_In_Price_Per_Kg")
                        .HasColumnType("float");

                    b.Property<double>("Stock_Out_Price_Per_Kg")
                        .HasColumnType("float");

                    b.Property<string>("Supplier_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FID");

                    b.ToTable("FarmProducts");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.OTHERSPREPAREDRECORD", b =>
                {
                    b.Property<int>("OTHRecIDPREP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OTHRecIDPREP"));

                    b.Property<int>("ItemIDPREP")
                        .HasColumnType("int");

                    b.Property<DateTime>("OTHRecDateSoldPREP")
                        .HasColumnType("datetime2");

                    b.Property<string>("OTHRecDescriptionPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTHRecNamePREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OTHRecSoldQuantityPREP")
                        .HasColumnType("float");

                    b.Property<double>("OTHRecStockInPricePREP")
                        .HasColumnType("float");

                    b.Property<double>("OTHRecStockOutPricePREP")
                        .HasColumnType("float");

                    b.Property<string>("OTHRecSupplierEmailPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OTHRecIDPREP");

                    b.ToTable("OTHERSPREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.OTHERSSALESRECORD", b =>
                {
                    b.Property<int>("OTHRecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OTHRecID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OTHRecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("OTHRecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTHRecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OTHRecSoldQuantity")
                        .HasColumnType("float");

                    b.Property<double>("OTHRecStockInPrice")
                        .HasColumnType("float");

                    b.Property<double>("OTHRecStockOutPrice")
                        .HasColumnType("float");

                    b.Property<string>("OTHRecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OTHRecID");

                    b.ToTable("OTHERSSALESRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.Others", b =>
                {
                    b.Property<int>("OID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OID"));

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiry_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Stock_In_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<double>("Stock_Out_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<string>("Supplier_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OID");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PACKEDFOODPREPAREDRECORD", b =>
                {
                    b.Property<int>("PARecIDPREP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PARecIDPREP"));

                    b.Property<int>("ItemIDPREP")
                        .HasColumnType("int");

                    b.Property<DateTime>("PARecDateSoldPREP")
                        .HasColumnType("datetime2");

                    b.Property<string>("PARecDescriptionPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PARecNamePREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PARecSoldQuantityPREP")
                        .HasColumnType("float");

                    b.Property<double>("PARecStockInPricePREP")
                        .HasColumnType("float");

                    b.Property<double>("PARecStockOutPricePREP")
                        .HasColumnType("float");

                    b.Property<string>("PARecSupplierEmailPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PARecIDPREP");

                    b.ToTable("PACKEDFOODPREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PACKEDFOODSSALESRECORD", b =>
                {
                    b.Property<int>("PARecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PARecID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PARecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("PARecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PARecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PARecSoldQuantity")
                        .HasColumnType("float");

                    b.Property<double>("PARecStockInPrice")
                        .HasColumnType("float");

                    b.Property<double>("PARecStockOutPrice")
                        .HasColumnType("float");

                    b.Property<string>("PARecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PARecID");

                    b.ToTable("PACKEDFOODSSALESRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PHARMACEUTICALSPREPAREDRECORD", b =>
                {
                    b.Property<int>("PHARecIDPREP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PHARecIDPREP"));

                    b.Property<int>("ItemIDPREP")
                        .HasColumnType("int");

                    b.Property<DateTime>("PHARecDateSoldPREP")
                        .HasColumnType("datetime2");

                    b.Property<string>("PHARecDescriptionPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHARecNamePREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PHARecSoldQuantityPREP")
                        .HasColumnType("float");

                    b.Property<double>("PHARecStockInPricePREP")
                        .HasColumnType("float");

                    b.Property<double>("PHARecStockOutPricePREP")
                        .HasColumnType("float");

                    b.Property<string>("PHARecSupplierEmailPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PHARecIDPREP");

                    b.ToTable("PHARMACEUTICALSPREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PHARMACEUTICALSSALESRECORD", b =>
                {
                    b.Property<int>("PHARecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PHARecID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PHARecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("PHARecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHARecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PHARecSoldQuantity")
                        .HasColumnType("float");

                    b.Property<double>("PHARecStockInPrice")
                        .HasColumnType("float");

                    b.Property<double>("PHARecStockOutPrice")
                        .HasColumnType("float");

                    b.Property<string>("PHARecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PHARecID");

                    b.ToTable("PHARMACEUTICALSSALESRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PREPAREDRECORD", b =>
                {
                    b.Property<int>("RecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecID"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RecSoldAmountQuantity")
                        .HasColumnType("float");

                    b.Property<double>("RecSt_InPrice")
                        .HasColumnType("float");

                    b.Property<double>("RecSt_OutPrice")
                        .HasColumnType("float");

                    b.Property<string>("RecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecID");

                    b.ToTable("PREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.PackedFoods", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PID"));

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiry_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Stock_In_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<double>("Stock_Out_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<string>("Supplier_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PID");

                    b.ToTable("PackedFoods");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.Pharmaceuticals", b =>
                {
                    b.Property<int>("PHID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PHID"));

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiry_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Stock_In_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<double>("Stock_Out_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<string>("Supplier_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PHID");

                    b.ToTable("Pharmaceuticals");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.TOOLSPREPAREDRECORD", b =>
                {
                    b.Property<int>("TOOLSRecIDPREP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TOOLSRecIDPREP"));

                    b.Property<int>("ItemIDPREP")
                        .HasColumnType("int");

                    b.Property<DateTime>("TOOLSRecDateSoldPREP")
                        .HasColumnType("datetime2");

                    b.Property<string>("TOOLSRecDescriptionPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TOOLSRecNamePREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TOOLSRecSoldQuantityPREP")
                        .HasColumnType("float");

                    b.Property<double>("TOOLSRecStockInPricePREP")
                        .HasColumnType("float");

                    b.Property<double>("TOOLSRecStockOutPricePREP")
                        .HasColumnType("float");

                    b.Property<string>("TOOLSRecSupplierEmailPREP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TOOLSRecIDPREP");

                    b.ToTable("TOOLSPREPAREDRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.TOOLSSALESRECORD", b =>
                {
                    b.Property<int>("TOOLSRecID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TOOLSRecID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TOOLSRecDateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("TOOLSRecDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TOOLSRecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TOOLSRecSoldQuantity")
                        .HasColumnType("float");

                    b.Property<double>("TOOLSRecStockInPrice")
                        .HasColumnType("float");

                    b.Property<double>("TOOLSRecStockOutPrice")
                        .HasColumnType("float");

                    b.Property<string>("TOOLSRecSupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TOOLSRecID");

                    b.ToTable("TOOLSSALESRECORD");
                });

            modelBuilder.Entity("SUP_INV1._0.Models.Tools", b =>
                {
                    b.Property<int>("TID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TID"));

                    b.Property<DateTime>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Stock_In_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<double>("Stock_Out_Price_Per_Item")
                        .HasColumnType("float");

                    b.Property<string>("Supplier_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TID");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
