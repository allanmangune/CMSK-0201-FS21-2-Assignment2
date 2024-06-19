﻿// <auto-generated />
using System;
using EFAssignment2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFAssignment2.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240606192729_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.31");

            modelBuilder.Entity("EFAssignment1.Core.Entities.Blog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BlogTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BlogTypeId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFAssignment1.Core.Entities.BlogType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BlogTypes");
                });

            modelBuilder.Entity("EFAssignment1.Core.Entities.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("PostTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFAssignment1.Core.Entities.PostType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PostTypes");
                });

            modelBuilder.Entity("EFAssignment1.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFAssignment1.Core.Entities.Blog", b =>
                {
                    b.HasOne("EFAssignment1.Core.Entities.BlogType", "BlogType")
                        .WithMany()
                        .HasForeignKey("BlogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogType");
                });
#pragma warning restore 612, 618
        }
    }
}
