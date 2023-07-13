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
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
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

                    b.ToTable("CollegeYears");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09878544-8945-4bb7-82c9-d567a2f632a4"),
                            Year = 1
                        },
                        new
                        {
                            Id = new Guid("c05db07a-5749-4278-886e-e2352907ccc3"),
                            Year = 2
                        },
                        new
                        {
                            Id = new Guid("7a0e332a-f33e-4112-93ce-4772ec1b6191"),
                            Year = 3
                        },
                        new
                        {
                            Id = new Guid("3cf3421b-7641-4709-bf90-b5f2f2226df4"),
                            Year = 4
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
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CollegeYearId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentService.Models.Student", b =>
                {
                    b.HasOne("StudentService.Models.CollegeYear", "CollegeYear")
                        .WithMany("Students")
                        .HasForeignKey("CollegeYearId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Student_College_Year");

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
