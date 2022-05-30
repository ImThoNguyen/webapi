USE TESTAPI
BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [Active] bit NULL;
GO

ALTER TABLE [Users] ADD [Address1] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [Address2] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [City] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [CommonName] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [Country] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [ExternalUser] bit NULL;
GO

ALTER TABLE [Users] ADD [FamilyName] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [FullName] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [GenderId] uniqueidentifier NULL;
GO

ALTER TABLE [Users] ADD [GivenName] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [MiddleName] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [Photo] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [Region] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [UserInfo] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [UserNote] nvarchar(max) NULL;
GO

ALTER TABLE [Users] ADD [Zip] nvarchar(max) NULL;
GO

CREATE TABLE [Genders] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [GenderName] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Users_GenderId] ON [Users] ([GenderId]);
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220530151859_CreateTableGender', N'5.0.17');
GO

COMMIT;
GO