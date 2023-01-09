﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnBoarding.Infrastructure.Data;

#nullable disable

namespace OnBoarding.Infrastructure.Migrations
{
    [DbContext(typeof(HRMDbContext))]
    partial class HRMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnBoarding.ApplicationCore.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeCategoryCodeCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeRoleIdRoleID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeStatusCodeStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeCategoryCodeCategoryID");

                    b.HasIndex("EmployeeRoleIdRoleID");

                    b.HasIndex("EmployeeStatusCodeStatusID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OnBoarding.ApplicationCore.Entities.EmployeeCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("EmployeeCategories");
                });

            modelBuilder.Entity("OnBoarding.ApplicationCore.Entities.EmployeeRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("OnBoarding.ApplicationCore.Entities.EmployeeStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("EmployeeStatuses");
                });

            modelBuilder.Entity("OnBoarding.ApplicationCore.Entities.Employee", b =>
                {
                    b.HasOne("OnBoarding.ApplicationCore.Entities.EmployeeCategory", "EmployeeCategoryCode")
                        .WithMany()
                        .HasForeignKey("EmployeeCategoryCodeCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnBoarding.ApplicationCore.Entities.EmployeeRole", "EmployeeRoleId")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleIdRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnBoarding.ApplicationCore.Entities.EmployeeStatus", "EmployeeStatusCode")
                        .WithMany()
                        .HasForeignKey("EmployeeStatusCodeStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeCategoryCode");

                    b.Navigation("EmployeeRoleId");

                    b.Navigation("EmployeeStatusCode");
                });
#pragma warning restore 612, 618
        }
    }
}
