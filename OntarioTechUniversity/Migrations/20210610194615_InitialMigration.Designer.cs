﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OntarioTechUniversity.Data;

namespace OntarioTechUniversity.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20210610194615_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OntarioTechUniversity.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationID2")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.HasIndex("LocationID");

                    b.HasIndex("LocationID2");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("OntarioTechUniversity.Models.Location", b =>
                {
                    b.Property<string>("LocationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("OntarioTechUniversity.Models.SafetyDataSheet", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<int>("LabNumber")
                        .HasColumnType("int");

                    b.Property<string>("LocationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationID2")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RevisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("LocationID");

                    b.HasIndex("LocationID2");

                    b.ToTable("SafetyDataSheet");
                });

            modelBuilder.Entity("OntarioTechUniversity.Models.Item", b =>
                {
                    b.HasOne("OntarioTechUniversity.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("OntarioTechUniversity.Models.Location", null)
                        .WithMany("Items")
                        .HasForeignKey("LocationID2")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OntarioTechUniversity.Models.SafetyDataSheet", b =>
                {
                    b.HasOne("OntarioTechUniversity.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("OntarioTechUniversity.Models.Location", null)
                        .WithMany("SafetyDataSheets")
                        .HasForeignKey("LocationID2");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OntarioTechUniversity.Models.Location", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("SafetyDataSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
