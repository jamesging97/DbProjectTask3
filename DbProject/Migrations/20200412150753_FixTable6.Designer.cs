﻿// <auto-generated />
using DbProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbProject.Migrations
{
    [DbContext(typeof(GradeDbContext))]
    [Migration("20200412150753_FixTable6")]
    partial class FixTable6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DbProject.Models.CourseModel", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Semester")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DbProject.Models.GradeReceivedModel", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<ushort>("Grade")
                        .HasColumnType("smallint unsigned");

                    b.Property<ushort>("Semester")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("StudentId", "CourseId");

                    b.ToTable("GradeReceived");
                });

            modelBuilder.Entity("DbProject.Models.InstructorModel", b =>
                {
                    b.Property<string>("InstructorId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Department")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InstructorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("DbProject.Models.StudentModel", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<ushort>("CreditsEarned")
                        .HasColumnType("smallint unsigned");

                    b.Property<double>("GPA")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DbProject.Models.TeachesModel", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("InstructorId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Semester")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseId", "InstructorId");

                    b.ToTable("Teaches");
                });
#pragma warning restore 612, 618
        }
    }
}
