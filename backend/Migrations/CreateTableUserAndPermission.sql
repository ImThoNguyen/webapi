USE TESTAPI
Go

BEGIN TRANSACTION;
GO

CREATE TABLE [DataProtectionKeys] (
    [Id] int NOT NULL IDENTITY,
    [FriendlyName] nvarchar(max) NULL,
    [Xml] nvarchar(max) NULL,
    CONSTRAINT [PK_DataProtectionKeys] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [AccountName] nvarchar(100) NULL,
    [Password] nvarchar(1024) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Permissions] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [PermissionName] nvarchar(300) NULL,
    [UsersId] uniqueidentifier NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permissions_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Permissions_UsersId] ON [Permissions] ([UsersId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220530131643_CreateTableUserAndPermission', N'5.0.17');
GO

COMMIT;
GO
