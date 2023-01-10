IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidates] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [ResumeURL] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeTypes] (
    [Id] int NOT NULL IDENTITY,
    [TypeName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeTypes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [JobCategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_JobCategories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [JobRequirements] (
    [Id] int NOT NULL IDENTITY,
    [NumberOfPosition] int NOT NULL,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [HiringManagerId] int NOT NULL,
    [HiringManagerName] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [ClosedOn] datetime2 NULL,
    [ClosedReason] nvarchar(max) NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [JobCategoryId] int NOT NULL,
    CONSTRAINT [PK_JobRequirements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobRequirements_JobCategories_JobCategoryId] FOREIGN KEY ([JobCategoryId]) REFERENCES [JobCategories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [EmployeeRequirementTypes] (
    [Id] int NOT NULL IDENTITY,
    [JobRequirementId] int NOT NULL,
    [EmployeeTypeId] int NOT NULL,
    CONSTRAINT [PK_EmployeeRequirementTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmployeeRequirementTypes_EmployeeTypes_EmployeeTypeId] FOREIGN KEY ([EmployeeTypeId]) REFERENCES [EmployeeTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeRequirementTypes_JobRequirements_JobRequirementId] FOREIGN KEY ([JobRequirementId]) REFERENCES [JobRequirements] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Submissions] (
    [Id] int NOT NULL IDENTITY,
    [JobRequirementId] int NOT NULL,
    [CandidateId] int NOT NULL,
    [SubmittedOn] datetime2 NOT NULL,
    [ConfirmedOn] datetime2 NOT NULL,
    [RejectedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submissions_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Submissions_JobRequirements_JobRequirementId] FOREIGN KEY ([JobRequirementId]) REFERENCES [JobRequirements] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Statuses] (
    [Id] int NOT NULL IDENTITY,
    [State] nvarchar(max) NOT NULL,
    [ChangedOn] datetime2 NULL,
    [StatusMessage] nvarchar(max) NOT NULL,
    [SubmissionId] int NOT NULL,
    CONSTRAINT [PK_Statuses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Statuses_Submissions_SubmissionId] FOREIGN KEY ([SubmissionId]) REFERENCES [Submissions] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_EmployeeRequirementTypes_EmployeeTypeId] ON [EmployeeRequirementTypes] ([EmployeeTypeId]);
GO

CREATE INDEX [IX_EmployeeRequirementTypes_JobRequirementId] ON [EmployeeRequirementTypes] ([JobRequirementId]);
GO

CREATE INDEX [IX_JobRequirements_JobCategoryId] ON [JobRequirements] ([JobCategoryId]);
GO

CREATE INDEX [IX_Statuses_SubmissionId] ON [Statuses] ([SubmissionId]);
GO

CREATE INDEX [IX_Submissions_CandidateId] ON [Submissions] ([CandidateId]);
GO

CREATE INDEX [IX_Submissions_JobRequirementId] ON [Submissions] ([JobRequirementId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230110192051_InitialCreate', N'7.0.2');
GO

COMMIT;
GO

