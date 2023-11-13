﻿// <auto-generated />
using System;
using KalbeTest.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KalbeTest.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20231113110042_AlterColumnNullable_OnMolecules")]
    partial class AlterColumnNullable_OnMolecules
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KalbeTest.Models.Molecules", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MolDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoleculesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("m_molecules");
                });

            modelBuilder.Entity("KalbeTest.Models.Study", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MoleculesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProtocolCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProtocolTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyStatusID")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("MoleculesID");

                    b.HasIndex("StudyStatusID");

                    b.ToTable("m_study");
                });

            modelBuilder.Entity("KalbeTest.Models.StudyStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("m_study_status");
                });

            modelBuilder.Entity("KalbeTest.Models.Study", b =>
                {
                    b.HasOne("KalbeTest.Models.Molecules", null)
                        .WithMany("Studies")
                        .HasForeignKey("MoleculesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KalbeTest.Models.StudyStatus", null)
                        .WithMany("Studies")
                        .HasForeignKey("StudyStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KalbeTest.Models.Molecules", b =>
                {
                    b.Navigation("Studies");
                });

            modelBuilder.Entity("KalbeTest.Models.StudyStatus", b =>
                {
                    b.Navigation("Studies");
                });
#pragma warning restore 612, 618
        }
    }
}
