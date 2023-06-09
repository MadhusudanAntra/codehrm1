USE [master]
GO
/****** Object:  Database [RecruitingDb]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE DATABASE [RecruitingDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecruitingDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RecruitingDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RecruitingDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RecruitingDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RecruitingDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecruitingDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecruitingDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecruitingDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecruitingDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecruitingDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecruitingDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecruitingDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RecruitingDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecruitingDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecruitingDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecruitingDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecruitingDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecruitingDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecruitingDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecruitingDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecruitingDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RecruitingDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecruitingDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecruitingDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecruitingDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecruitingDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecruitingDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RecruitingDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecruitingDb] SET RECOVERY FULL 
GO
ALTER DATABASE [RecruitingDb] SET  MULTI_USER 
GO
ALTER DATABASE [RecruitingDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecruitingDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecruitingDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecruitingDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RecruitingDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RecruitingDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RecruitingDb', N'ON'
GO
ALTER DATABASE [RecruitingDb] SET QUERY_STORE = OFF
GO
USE [RecruitingDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ResumeURL] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRequirementTypes]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRequirementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobRequirementId] [int] NOT NULL,
	[EmployeeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeRequirementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTypes]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmployeeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobCategories]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JobCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobRequirements]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobRequirements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfPosition] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[HiringManagerId] [int] NOT NULL,
	[HiringManagerName] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ClosedOn] [datetime2](7) NULL,
	[ClosedReason] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[JobCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_JobRequirements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[ChangedOn] [datetime2](7) NULL,
	[StatusMessage] [nvarchar](max) NOT NULL,
	[SubmissionId] [int] NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submissions]    Script Date: 1/10/2023 3:44:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobRequirementId] [int] NOT NULL,
	[CandidateId] [int] NOT NULL,
	[SubmittedOn] [datetime2](7) NOT NULL,
	[ConfirmedOn] [datetime2](7) NOT NULL,
	[RejectedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Submissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeRequirementTypes_EmployeeTypeId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeRequirementTypes_EmployeeTypeId] ON [dbo].[EmployeeRequirementTypes]
(
	[EmployeeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeRequirementTypes_JobRequirementId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeRequirementTypes_JobRequirementId] ON [dbo].[EmployeeRequirementTypes]
(
	[JobRequirementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobRequirements_JobCategoryId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_JobRequirements_JobCategoryId] ON [dbo].[JobRequirements]
(
	[JobCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Statuses_SubmissionId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_Statuses_SubmissionId] ON [dbo].[Statuses]
(
	[SubmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Submissions_CandidateId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_CandidateId] ON [dbo].[Submissions]
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Submissions_JobRequirementId]    Script Date: 1/10/2023 3:44:46 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_JobRequirementId] ON [dbo].[Submissions]
(
	[JobRequirementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeRequirementTypes]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRequirementTypes_EmployeeTypes_EmployeeTypeId] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRequirementTypes] CHECK CONSTRAINT [FK_EmployeeRequirementTypes_EmployeeTypes_EmployeeTypeId]
GO
ALTER TABLE [dbo].[EmployeeRequirementTypes]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRequirementTypes_JobRequirements_JobRequirementId] FOREIGN KEY([JobRequirementId])
REFERENCES [dbo].[JobRequirements] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRequirementTypes] CHECK CONSTRAINT [FK_EmployeeRequirementTypes_JobRequirements_JobRequirementId]
GO
ALTER TABLE [dbo].[JobRequirements]  WITH CHECK ADD  CONSTRAINT [FK_JobRequirements_JobCategories_JobCategoryId] FOREIGN KEY([JobCategoryId])
REFERENCES [dbo].[JobCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobRequirements] CHECK CONSTRAINT [FK_JobRequirements_JobCategories_JobCategoryId]
GO
ALTER TABLE [dbo].[Statuses]  WITH CHECK ADD  CONSTRAINT [FK_Statuses_Submissions_SubmissionId] FOREIGN KEY([SubmissionId])
REFERENCES [dbo].[Submissions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Statuses] CHECK CONSTRAINT [FK_Statuses_Submissions_SubmissionId]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Candidates_CandidateId] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Candidates_CandidateId]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_JobRequirements_JobRequirementId] FOREIGN KEY([JobRequirementId])
REFERENCES [dbo].[JobRequirements] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_JobRequirements_JobRequirementId]
GO
USE [master]
GO
ALTER DATABASE [RecruitingDb] SET  READ_WRITE 
GO
