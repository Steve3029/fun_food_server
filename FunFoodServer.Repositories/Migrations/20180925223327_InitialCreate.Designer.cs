﻿// <auto-generated />
using System;
using FunFoodServer.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FunFoodServer.Repositories.Migrations
{
    [DbContext(typeof(FunFoodDbContext))]
    [Migration("20180925223327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("FunFood")
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FunFoodServer.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .HasName("Index_Email");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("FunFoodServer.Domain.Model.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Facebook");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("GooglePlus");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<string>("Twitter");

                    b.Property<Guid>("UserId");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("USER_PROFILE");
                });

            modelBuilder.Entity("FunFoodServer.Domain.Model.UserProfile", b =>
                {
                    b.HasOne("FunFoodServer.Domain.Model.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("FunFoodServer.Domain.Model.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
