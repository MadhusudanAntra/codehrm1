﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recruiting.Infrastructure.Data;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    [DbContext(typeof(RecruitingDbContext))]
    partial class RecruitingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.EmployeeRequirementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeTypeId");

                    b.HasIndex("JobRequirementId");

                    b.ToTable("EmployeeRequirementTypes");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.EmployeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTypes");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.JobRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClosedReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HiringManagerId")
                        .HasColumnType("int");

                    b.Property<string>("HiringManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPosition")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobRequirements");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ChangedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.Property<int>("MostRecentStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RejectedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobRequirementId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.EmployeeRequirementType", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entities.EmployeeType", "EmployeeType")
                        .WithMany("EmployeeRequirementTypes")
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recruiting.ApplicationCore.Entities.JobRequirement", "JobRequirement")
                        .WithMany("EmployeeRequirementType")
                        .HasForeignKey("JobRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeType");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.JobRequirement", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entities.JobCategory", "JobCategory")
                        .WithMany("JobRequirements")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Status", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entities.Submission", "Submission")
                        .WithMany("Status")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Submission", b =>
                {
                    b.HasOne("Recruiting.ApplicationCore.Entities.Candidate", "Candidate")
                        .WithMany("Submissions")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recruiting.ApplicationCore.Entities.JobRequirement", "JobRequirement")
                        .WithMany("Submissions")
                        .HasForeignKey("JobRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Candidate", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.EmployeeType", b =>
                {
                    b.Navigation("EmployeeRequirementTypes");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.JobCategory", b =>
                {
                    b.Navigation("JobRequirements");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.JobRequirement", b =>
                {
                    b.Navigation("EmployeeRequirementType");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting.ApplicationCore.Entities.Submission", b =>
                {
                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
