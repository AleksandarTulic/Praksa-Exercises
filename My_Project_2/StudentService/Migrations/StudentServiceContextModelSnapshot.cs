﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentService.Data;

#nullable disable

namespace StudentService.Migrations
{
    [DbContext(typeof(StudentServiceContext))]
    partial class StudentServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentService.Models.CollegeYear", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CollegeYear");

                    b.HasData(
                        new
                        {
                            Id = new Guid("32e71d2e-859b-4a31-889b-14965c80f179"),
                            Year = 1
                        },
                        new
                        {
                            Id = new Guid("b150e415-4e1f-4ffd-a13a-5a5de2bf03ab"),
                            Year = 2
                        },
                        new
                        {
                            Id = new Guid("d319c73b-bf4a-46a2-9d8e-e0e72eb307b8"),
                            Year = 3
                        },
                        new
                        {
                            Id = new Guid("16b12c21-a061-4940-9fb5-f2272a18aaeb"),
                            Year = 4
                        },
                        new
                        {
                            Id = new Guid("f831ba0a-9f06-47c3-a46f-b350a07c203e"),
                            Year = 5
                        },
                        new
                        {
                            Id = new Guid("83c00dfc-8832-41ac-8ac6-78d956cb6fad"),
                            Year = 6
                        });
                });

            modelBuilder.Entity("StudentService.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CollegeYearId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Enrolled")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CollegeYearId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentService.Models.Student", b =>
                {
                    b.HasOne("StudentService.Models.CollegeYear", "CollegeYear")
                        .WithMany("Students")
                        .HasForeignKey("CollegeYearId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Student_CollegeYear");

                    b.Navigation("CollegeYear");
                });

            modelBuilder.Entity("StudentService.Models.CollegeYear", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}