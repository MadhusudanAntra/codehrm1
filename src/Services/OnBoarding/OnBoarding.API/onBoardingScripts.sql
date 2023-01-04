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

CREATE TABLE [EmployeeCategories] (
    [CategoryID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeCategories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [EmployeeRoles] (
    [RoleID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY ([RoleID])
);
GO

CREATE TABLE [EmployeeStatuses] (
    [StatusID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeStatuses] PRIMARY KEY ([StatusID])
);
GO

CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NOT NULL,
    [SSN] nvarchar(max) NOT NULL,
    [HireDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [EmployeeCategoryCodeCategoryID] int NOT NULL,
    [EmployeeStatusCodeStatusID] int NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [EmployeeRoleIdRoleID] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId]),
    CONSTRAINT [FK_Employees_EmployeeCategories_EmployeeCategoryCodeCategoryID] FOREIGN KEY ([EmployeeCategoryCodeCategoryID]) REFERENCES [EmployeeCategories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employees_EmployeeRoles_EmployeeRoleIdRoleID] FOREIGN KEY ([EmployeeRoleIdRoleID]) REFERENCES [EmployeeRoles] ([RoleID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employees_EmployeeStatuses_EmployeeStatusCodeStatusID] FOREIGN KEY ([EmployeeStatusCodeStatusID]) REFERENCES [EmployeeStatuses] ([StatusID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Employees_EmployeeCategoryCodeCategoryID] ON [Employees] ([EmployeeCategoryCodeCategoryID]);
GO

CREATE INDEX [IX_Employees_EmployeeRoleIdRoleID] ON [Employees] ([EmployeeRoleIdRoleID]);
GO

CREATE INDEX [IX_Employees_EmployeeStatusCodeStatusID] ON [Employees] ([EmployeeStatusCodeStatusID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221219204211_InitialMigration', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221221193045_secondMigration', N'7.0.1');
GO

COMMIT;
GO

