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

                    b.Property<int?>("ProductModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductModelId");

                    b.ToTable("CategoryModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ProductModel", b =>
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

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("ServiceModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServiceModelId");

                    b.ToTable("ProductModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WaiterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ServiceModel");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.TableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartAt")
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

            modelBuilder.Entity("TodoApi.Data.Repository.Models.CategoryModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.ProductModel", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductModelId");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ProductModel", b =>
                {
                    b.HasOne("TodoApi.Data.Repository.Models.ServiceModel", null)
                        .WithMany("Products")
                        .HasForeignKey("ServiceModelId");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ProductModel", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("TodoApi.Data.Repository.Models.ServiceModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
