﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eshop.Infrastructure.Data;

#nullable disable

namespace eshop.Infrastructure.Migrations
{
    [DbContext(typeof(EshopDbContext))]
    partial class EshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eshop.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Elektronik"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kırtasiye"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Giyim"
                        });
                });

            modelBuilder.Entity("eshop.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Kulaklık",
                            ImageURL = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg",
                            Name = "Bluetooth kulaklık",
                            Price = 500m,
                            Rating = 4.2000000000000002
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "150 x 250",
                            ImageURL = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg",
                            Name = "Yazı tahtası",
                            Price = 1000m,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Şort işte",
                            ImageURL = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg",
                            Name = "Şort",
                            Price = 400m,
                            Rating = 4.2000000000000002
                        });
                });

            modelBuilder.Entity("eshop.Entities.Product", b =>
                {
                    b.HasOne("eshop.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eshop.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
