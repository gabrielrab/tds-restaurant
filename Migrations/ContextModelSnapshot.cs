﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Data.Repository;

#nullable disable

namespace TodoApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ProductModelServiceModel", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServicesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ProductModelServiceModel");
                });

            modelBuilder.Entity("ServiceModelWaiterModel", b =>
                {
                    b.Property<int>("ServicesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WaitersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServicesId", "WaitersId");

                    b.HasIndex("WaitersId");

                    b.ToTable("ServiceModelWaiterModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoryModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("ServiceModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.TableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TableModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.WaiterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WaiterModel");
                });

            modelBuilder.Entity("ProductModelServiceModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Data.Repository.Models.ServiceModel", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceModelWaiterModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.ServiceModel", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Data.Repository.Models.WaiterModel", null)
                        .WithMany()
                        .HasForeignKey("WaitersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ProductModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.CategoryModel", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ServiceModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.TableModel", "Table")
                        .WithMany("Services")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.CategoryModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.TableModel", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}