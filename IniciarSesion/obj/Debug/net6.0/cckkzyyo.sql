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

CREATE TABLE [Register] (
    [Id] bigint NOT NULL IDENTITY,
    [NameId] nvarchar(max) NOT NULL,
    [UserNameId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Register] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [UserId] bigint NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [UserName] nvarchar(100) NOT NULL,
    [password] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221021033938_inicial', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[User].[password]', N'Password', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221128222005_inicio', N'6.0.10');
GO

COMMIT;
GO

