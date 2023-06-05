﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductsManagement.DAL.Data;

#nullable disable

namespace ProductsManagement.DAL.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20230403200644_ProductsMigrations")]
    partial class ProductsMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductOffers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Instock")
                        .HasColumnType("boolean")
                        .HasColumnName("instock");

                    b.Property<string>("OfferUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("offerurl");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<double?>("ShippingCost")
                        .HasColumnType("double precision")
                        .HasColumnName("shippingcost");

                    b.Property<string>("Shop")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("shop");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("productoffers", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("photourl");

                    b.Property<int>("TrackedProductsId")
                        .HasColumnType("integer")
                        .HasColumnName("trackedproductsid");

                    b.HasKey("Id");

                    b.HasIndex("TrackedProductsId");

                    b.ToTable("productphotos", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductPrices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("TrackedProductsId")
                        .HasColumnType("integer")
                        .HasColumnName("trackedproductsid");

                    b.HasKey("Id");

                    b.HasIndex("TrackedProductsId");

                    b.ToTable("productprices", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<string>("ReviewContent")
                        .HasColumnType("character varying")
                        .HasColumnName("reviewcontent");

                    b.Property<int>("TrackedProductsId")
                        .HasColumnType("integer");

                    b.Property<string>("UserPhoto")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TrackedProductsId");

                    b.ToTable("reviewproducts", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.RuleSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Instock")
                        .HasColumnType("boolean")
                        .HasColumnName("instock");

                    b.Property<double?>("Maxvalue")
                        .HasColumnType("double precision")
                        .HasColumnName("maxvalue");

                    b.Property<double?>("Minvalue")
                        .HasColumnType("double precision")
                        .HasColumnName("minvalue");

                    b.Property<bool?>("Outstock")
                        .HasColumnType("boolean")
                        .HasColumnName("outstock");

                    b.HasKey("Id");

                    b.ToTable("rulesets", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.TrackedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("Aproximateprofit")
                        .HasColumnType("double precision")
                        .HasColumnName("aproximateprofit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<double>("Maxprice")
                        .HasColumnType("double precision")
                        .HasColumnName("maxprice");

                    b.Property<double>("Minprice")
                        .HasColumnType("double precision")
                        .HasColumnName("minprice");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Producturl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("producturl");

                    b.Property<double?>("Ratingbyreviews")
                        .HasColumnType("double precision")
                        .HasColumnName("ratingbyreviews");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Producturl" }, "trackedproducts_producturl_key")
                        .IsUnique();

                    b.ToTable("trackedproducts", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.UserLikedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("userlikedproducts", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.UserTrackedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("RulesetId")
                        .HasColumnType("integer")
                        .HasColumnName("rulesetid");

                    b.Property<int>("TrackedproductsId")
                        .HasColumnType("integer")
                        .HasColumnName("trackedproductsid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("RulesetId");

                    b.HasIndex("TrackedproductsId");

                    b.ToTable("usertrackedproducts", (string)null);
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductOffers", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "Product")
                        .WithMany("ProductOffers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("productoffers_productid_fkey");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductPhotos", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "TrackedProduct")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("TrackedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("productphotos_trackedproductsid_fkey");

                    b.Navigation("TrackedProduct");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductPrices", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "TrackedProduct")
                        .WithMany("ProductPrices")
                        .HasForeignKey("TrackedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("productprices_trackedproductsid_fkey");

                    b.Navigation("TrackedProduct");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.ProductReviews", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "TrackedProduct")
                        .WithMany("ReviewProducts")
                        .HasForeignKey("TrackedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrackedProduct");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.UserLikedProducts", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "Product")
                        .WithMany("UserLikedProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("userlikedproducts_productid_fkey");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.UserTrackedProducts", b =>
                {
                    b.HasOne("ProductsManagement.DAL.Entities.RuleSet", "RuleSet")
                        .WithMany("UserTrackedProducts")
                        .HasForeignKey("RulesetId")
                        .HasConstraintName("usertrackedproducts_rulesetid_fkey");

                    b.HasOne("ProductsManagement.DAL.Entities.TrackedProducts", "TrackedProduct")
                        .WithMany("UserTrackedProducts")
                        .HasForeignKey("TrackedproductsId")
                        .IsRequired()
                        .HasConstraintName("usertrackedproducts_trackedproductsid_fkey");

                    b.Navigation("RuleSet");

                    b.Navigation("TrackedProduct");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.RuleSet", b =>
                {
                    b.Navigation("UserTrackedProducts");
                });

            modelBuilder.Entity("ProductsManagement.DAL.Entities.TrackedProducts", b =>
                {
                    b.Navigation("ProductOffers");

                    b.Navigation("ProductPhotos");

                    b.Navigation("ProductPrices");

                    b.Navigation("ReviewProducts");

                    b.Navigation("UserLikedProducts");

                    b.Navigation("UserTrackedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
