﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reporting.Data;

#nullable disable

namespace Reporting.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250221233956_initial Reporting")]
    partial class initialReporting
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessTracker.Reporting.Models.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Reporting.Models.Stats", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Completed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfPeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("NofWorkout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pending")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartPeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeOut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique()
                        .HasFilter("[ReportId] IS NOT NULL");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Reporting.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Reporting.Models.WorkOut", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkOuts", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("FitnessTracker.Reporting.Models.Report", b =>
                {
                    b.HasOne("Reporting.Models.User", "user")
                        .WithMany("reports")
                        .HasForeignKey("UserId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Reporting.Models.Stats", b =>
                {
                    b.HasOne("FitnessTracker.Reporting.Models.Report", "reports")
                        .WithOne("Stats")
                        .HasForeignKey("Reporting.Models.Stats", "ReportId");

                    b.Navigation("reports");
                });

            modelBuilder.Entity("FitnessTracker.Reporting.Models.Report", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("Reporting.Models.User", b =>
                {
                    b.Navigation("reports");
                });
#pragma warning restore 612, 618
        }
    }
}
