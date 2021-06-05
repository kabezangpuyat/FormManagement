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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF SCHEMA_ID(N'shared') IS NULL EXEC(N'CREATE SCHEMA [shared];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE SEQUENCE [shared].[OrderNumbers] AS int START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[AppNavigation] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NULL,
        [IsInitialPage] bit NOT NULL DEFAULT CAST(0 AS bit),
        [IsMainModule] bit NOT NULL DEFAULT CAST(0 AS bit),
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4287023+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_AppNavigation] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[Campaign] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [EpmsCampaignID] bigint NOT NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4688305+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Campaign] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[FormCategory] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4708305+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_FormCategory] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[FormChoice] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Value] int NOT NULL,
        [SortOrder] int NOT NULL DEFAULT (NEXT VALUE FOR shared.OrderNumbers),
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4744839+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_FormChoice] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[FormType] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4888152+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_FormType] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[Role] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [Description] nvarchar(max) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.5010013+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Role] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[User] (
        [ID] bigint NOT NULL IDENTITY,
        [Key] uniqueidentifier NOT NULL DEFAULT '60066c26-fc5c-4f61-9d50-176ab47c80a5',
        [Username] nvarchar(100) NOT NULL,
        [Password] nvarchar(max) NULL,
        [Email] nvarchar(100) NULL,
        [FirstName] nvarchar(100) NULL,
        [LastName] nvarchar(100) NULL,
        [MiddleName] nvarchar(max) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.5095626+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_User] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[Lob] (
        [ID] bigint NOT NULL IDENTITY,
        [CampaignID] bigint NULL,
        [Name] nvarchar(100) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4938867+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Lob] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Lob_Campaign_CampaignID] FOREIGN KEY ([CampaignID]) REFERENCES [dbo].[Campaign] ([ID]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[HtmlControl] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [FormTypeID] bigint NULL,
        [FormCategoryID] bigint NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4914371+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_HtmlControl] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_HtmlControl_FormCategory_FormCategoryID] FOREIGN KEY ([FormCategoryID]) REFERENCES [dbo].[FormCategory] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_HtmlControl_FormType_FormTypeID] FOREIGN KEY ([FormTypeID]) REFERENCES [dbo].[FormType] ([ID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[RoleAppNavigation] (
        [ID] bigint NOT NULL IDENTITY,
        [AppNavigationID] bigint NOT NULL,
        [RoleID] bigint NOT NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4982061+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_RoleAppNavigation] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_RoleAppNavigation_AppNavigation_AppNavigationID] FOREIGN KEY ([AppNavigationID]) REFERENCES [dbo].[AppNavigation] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_RoleAppNavigation_Role_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[Form] (
        [ID] bigint NOT NULL IDENTITY,
        [Key] uniqueidentifier NOT NULL DEFAULT '58a1327a-6201-42c5-a317-97a503ea4dff',
        [FormTypeID] bigint NOT NULL,
        [FormCategoryID] bigint NOT NULL,
        [Name] nvarchar(100) NULL,
        [IsNoteVisible] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4784338+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Form] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Form_FormCategory_FormCategoryID] FOREIGN KEY ([FormCategoryID]) REFERENCES [dbo].[FormCategory] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Form_FormType_FormTypeID] FOREIGN KEY ([FormTypeID]) REFERENCES [dbo].[FormType] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Form_User_CreatedByID] FOREIGN KEY ([CreatedByID]) REFERENCES [dbo].[User] ([ID]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[RefreshToken] (
        [ID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [Token] nvarchar(max) NULL,
        [Expires] datetime2 NOT NULL,
        [Created] datetime2 NOT NULL,
        [CreatedByIp] nvarchar(max) NULL,
        [Revoked] datetime2 NULL,
        [RevokedByIp] nvarchar(max) NULL,
        [ReplacedByToken] nvarchar(max) NULL,
        CONSTRAINT [PK_RefreshToken] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_RefreshToken_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[UserCampaign] (
        [ID] bigint NOT NULL IDENTITY,
        [UserID] bigint NULL,
        [CampaignID] bigint NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.5058731+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_UserCampaign] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_UserCampaign_Campaign_CampaignID] FOREIGN KEY ([CampaignID]) REFERENCES [dbo].[Campaign] ([ID]) ON DELETE SET NULL,
        CONSTRAINT [FK_UserCampaign_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[UserRole] (
        [ID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [RoleID] bigint NOT NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.5124004+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_UserRole_Role_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRole_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[Audit] (
        [ID] bigint NOT NULL IDENTITY,
        [FormID] bigint NOT NULL,
        [TeammateID] bigint NOT NULL,
        [Name] nvarchar(300) NULL,
        [FormNotes] nvarchar(max) NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4401717+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Audit] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Audit_Form_FormID] FOREIGN KEY ([FormID]) REFERENCES [dbo].[Form] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Audit_User_CreatedByID] FOREIGN KEY ([CreatedByID]) REFERENCES [dbo].[User] ([ID]) ON DELETE SET NULL,
        CONSTRAINT [FK_Audit_User_TeammateID] FOREIGN KEY ([TeammateID]) REFERENCES [dbo].[User] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[FormQuestion] (
        [ID] bigint NOT NULL IDENTITY,
        [FormID] bigint NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [HtmlControlID] bigint NOT NULL,
        [IsNoteVisible] bit NOT NULL DEFAULT CAST(0 AS bit),
        [SortOrder] int NOT NULL DEFAULT (NEXT VALUE FOR shared.OrderNumbers),
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4859712+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_FormQuestion] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_FormQuestion_Form_FormID] FOREIGN KEY ([FormID]) REFERENCES [dbo].[Form] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_FormQuestion_HtmlControl_HtmlControlID] FOREIGN KEY ([HtmlControlID]) REFERENCES [dbo].[HtmlControl] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[AuditDetail] (
        [ID] bigint NOT NULL IDENTITY,
        [AuditID] bigint NOT NULL,
        [QuestionID] bigint NULL,
        [ChoiceID] bigint NULL,
        [QuestionNotes] nvarchar(max) NULL,
        [UserID] bigint NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4611874+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_AuditDetail] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_AuditDetail_Audit_AuditID] FOREIGN KEY ([AuditID]) REFERENCES [dbo].[Audit] ([ID]),
        CONSTRAINT [FK_AuditDetail_FormChoice_ChoiceID] FOREIGN KEY ([ChoiceID]) REFERENCES [dbo].[FormChoice] ([ID]) ON DELETE SET NULL,
        CONSTRAINT [FK_AuditDetail_FormQuestion_QuestionID] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[FormQuestion] ([ID]) ON DELETE SET NULL,
        CONSTRAINT [FK_AuditDetail_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE TABLE [dbo].[FormQuestionChoice] (
        [ID] bigint NOT NULL IDENTITY,
        [QuestionID] bigint NOT NULL,
        [ChoiceID] bigint NOT NULL,
        [CreatedByID] bigint NULL,
        [ModifiedByID] bigint NULL,
        [DateCreated] datetimeoffset NOT NULL DEFAULT '2021-06-05T13:07:13.4819155+08:00',
        [DateModified] datetimeoffset NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_FormQuestionChoice] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_FormQuestionChoice_FormChoice_ChoiceID] FOREIGN KEY ([ChoiceID]) REFERENCES [dbo].[FormChoice] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_FormQuestionChoice_FormQuestion_QuestionID] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[FormQuestion] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5215186+08:00'', NULL, N''User management navigation'', CAST(1 AS bit), NULL, N''user'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [ModifiedByID], [Name])
    VALUES (CAST(13 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216851+08:00'', NULL, N''Audit/report details view'', NULL, N''audit-details-view''),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216847+08:00'', NULL, N''Admin - Form Create Update'', NULL, N''form-update'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsInitialPage], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216843+08:00'', NULL, N''TM - Audit Summary'', CAST(1 AS bit), CAST(1 AS bit), NULL, N''report-TM''),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216840+08:00'', NULL, N''TL - Audit Summary'', CAST(1 AS bit), CAST(1 AS bit), NULL, N''report-tl'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [ModifiedByID], [Name])
    VALUES (CAST(8 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216771+08:00'', NULL, N''QA - Audit Record Create'', NULL, N''audit-create''),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216835+08:00'', NULL, N''QA - Report'', NULL, N''report-qa''),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216765+08:00'', NULL, N''QA - Form Create Update'', NULL, N''form-createupdate-qa'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216763+08:00'', NULL, N''QA - Form Management'', CAST(1 AS bit), NULL, N''form-qa'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsInitialPage], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216759+08:00'', NULL, N''Admin - Audit Summary'', CAST(1 AS bit), CAST(1 AS bit), NULL, N''report-admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [ModifiedByID], [Name])
    VALUES (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216755+08:00'', NULL, N''Admin - Form Create Update'', NULL, N''form-create'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216702+08:00'', NULL, N''Admin - Form Management'', CAST(1 AS bit), NULL, N''form-admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[AppNavigation] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [IsInitialPage], [IsMainModule], [ModifiedByID], [Name])
    VALUES (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5216768+08:00'', NULL, N''QA - Audit Record List'', CAST(1 AS bit), CAST(1 AS bit), NULL, N''audit-qa'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'IsInitialPage', N'IsMainModule', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[AppNavigation]'))
        SET IDENTITY_INSERT [dbo].[AppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'EpmsCampaignID', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Campaign]'))
        SET IDENTITY_INSERT [dbo].[Campaign] ON;
    EXEC(N'INSERT INTO [dbo].[Campaign] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [EpmsCampaignID], [ModifiedByID], [Name])
    VALUES (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5143549+08:00'', NULL, CAST(1389 AS bigint), NULL, N''Finance''),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5142415+08:00'', NULL, CAST(420 AS bigint), NULL, N''IT''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5143507+08:00'', NULL, CAST(22 AS bigint), NULL, N''Operations''),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5143545+08:00'', NULL, CAST(373 AS bigint), NULL, N''Data Science'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'EpmsCampaignID', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Campaign]'))
        SET IDENTITY_INSERT [dbo].[Campaign] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[FormCategory]'))
        SET IDENTITY_INSERT [dbo].[FormCategory] ON;
    EXEC(N'INSERT INTO [dbo].[FormCategory] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [Name])
    VALUES (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5243682+08:00'', NULL, NULL, N''Multiple Choices Form''),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5243680+08:00'', NULL, NULL, N''Yes/No/NA Form''),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5243637+08:00'', NULL, NULL, N''Yes | No Form''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5243677+08:00'', NULL, NULL, N''True | False Form'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[FormCategory]'))
        SET IDENTITY_INSERT [dbo].[FormCategory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name', N'SortOrder', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[FormChoice]'))
        SET IDENTITY_INSERT [dbo].[FormChoice] ON;
    EXEC(N'INSERT INTO [dbo].[FormChoice] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [Name], [SortOrder], [Value])
    VALUES (CAST(23 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275603+08:00'', NULL, NULL, N''Agent used unfamiliar language'', 23, 4),
    (CAST(24 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275605+08:00'', NULL, NULL, N''Poor Communication (voice/format/text)'', 24, 3),
    (CAST(25 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275608+08:00'', NULL, NULL, N''Meets Expecations'', 25, 10),
    (CAST(26 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275610+08:00'', NULL, NULL, N''[CRITICAL ERROR] Agent used inapproriate language'', 26, -25),
    (CAST(27 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275612+08:00'', NULL, NULL, N''[CRITICAL ERROR] Agent cursed, yelled, was rude'', 27, -25),
    (CAST(28 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275614+08:00'', NULL, NULL, N''Excessive hold time'', 28, 10),
    (CAST(29 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275616+08:00'', NULL, NULL, N''Meets Expectations'', 29, 10),
    (CAST(30 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275664+08:00'', NULL, NULL, N''[CRITICAL ERROR] Did not link with correct delivery/email'', 30, -25),
    (CAST(31 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275668+08:00'', NULL, NULL, N''[CRITICAL ERROR] Did not link with correct delivery/email'', 31, -25),
    (CAST(32 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275670+08:00'', NULL, NULL, N''Did not duplicate/merge cases'', 32, 5),
    (CAST(34 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275674+08:00'', NULL, NULL, N''Did not set case status appropriately'', 34, 5),
    (CAST(35 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275676+08:00'', NULL, NULL, N''Did not select correct Issue/Issue Cat'', 35, 1),
    (CAST(36 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275678+08:00'', NULL, NULL, N''Incorrect Resolution/Category'', 36, 1),
    (CAST(37 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275680+08:00'', NULL, NULL, N''Did not associate correct account name'', 37, 1),
    (CAST(38 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275683+08:00'', NULL, NULL, N''Did not log call to the case'', 38, 1),
    (CAST(39 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275685+08:00'', NULL, NULL, N''Did not update to correct case origin'', 39, 1),
    (CAST(40 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275687+08:00'', NULL, NULL, N''Meets Expectations'', 40, 20),
    (CAST(33 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275672+08:00'', NULL, NULL, N''Did not include sufficient case notes'', 33, 5),
    (CAST(21 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275599+08:00'', NULL, NULL, N''Meets Expectations'', 21, 35),
    (CAST(22 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275601+08:00'', NULL, NULL, N''Agent was not easy to understand'', 22, 3),
    (CAST(19 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275595+08:00'', NULL, NULL, N''Escalated without appropriate case notes'', 19, 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name', N'SortOrder', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[FormChoice]'))
        SET IDENTITY_INSERT [dbo].[FormChoice] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name', N'SortOrder', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[FormChoice]'))
        SET IDENTITY_INSERT [dbo].[FormChoice] ON;
    EXEC(N'INSERT INTO [dbo].[FormChoice] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [Name], [SortOrder], [Value])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275482+08:00'', NULL, NULL, N''Yes'', 1, 1),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275557+08:00'', NULL, NULL, N''No'', 2, 0),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275560+08:00'', NULL, NULL, N''NA'', 3, 2),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275563+08:00'', NULL, NULL, N''True'', 4, 1),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275565+08:00'', NULL, NULL, N''False'', 5, 0),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275567+08:00'', NULL, NULL, N''[CRITICAL ERROR] Agent shared private information'', 6, -25),
    (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275569+08:00'', NULL, NULL, N''[CRITICAL ERROR] Did not take ownership of the case'', 7, -25),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275571+08:00'', NULL, NULL, N''[CRITICAL ERROR] Did not use/complete WFT'', 8, -25),
    (CAST(20 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275597+08:00'', NULL, NULL, N''Failed to follow through with request'', 20, 15),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275574+08:00'', NULL, NULL, N''Process was not followed'', 9, 7),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275578+08:00'', NULL, NULL, N''Did not attach KB as appropriate'', 11, 7),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275580+08:00'', NULL, NULL, N''Did not follow CSAT positioning'', 12, 1),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275582+08:00'', NULL, NULL, N''Meets Expectations'', 13, 25),
    (CAST(14 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275584+08:00'', NULL, NULL, N''[CRITICAL ERROR] Failure to properly follow-up/escalate'', 14, -25),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275587+08:00'', NULL, NULL, N''[CRITICAL ERROR] - Agent failed to OB on dropped contact'', 15, -25),
    (CAST(16 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275589+08:00'', NULL, NULL, N''[CRITICAL ERROR] Did not correctly escalate Covid-19 case'', 16, -25),
    (CAST(17 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275591+08:00'', NULL, NULL, N''[CRITICAL ERROR] Failed to escalate a HSL case'', 17, -25),
    (CAST(18 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275593+08:00'', NULL, NULL, N''Transferred without a justified reason'', 18, 10),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5275576+08:00'', NULL, NULL, N''Provided inaccurate information'', 10, 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name', N'SortOrder', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[FormChoice]'))
        SET IDENTITY_INSERT [dbo].[FormChoice] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[FormType]'))
        SET IDENTITY_INSERT [dbo].[FormType] ON;
    EXEC(N'INSERT INTO [dbo].[FormType] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [Name])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5238985+08:00'', NULL, NULL, N''QA Form''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5239029+08:00'', NULL, NULL, N''Survey Form'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[FormType]'))
        SET IDENTITY_INSERT [dbo].[FormType] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormCategoryID', N'FormTypeID', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[HtmlControl]'))
        SET IDENTITY_INSERT [dbo].[HtmlControl] ON;
    EXEC(N'INSERT INTO [dbo].[HtmlControl] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormCategoryID], [FormTypeID], [ModifiedByID], [Name])
    VALUES (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5235151+08:00'', NULL, NULL, NULL, NULL, N''Checkbox''),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5235149+08:00'', NULL, NULL, NULL, NULL, N''Textbox''),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5235071+08:00'', NULL, NULL, NULL, NULL, N''Option''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5235146+08:00'', NULL, NULL, NULL, NULL, N''Dropdown'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormCategoryID', N'FormTypeID', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[HtmlControl]'))
        SET IDENTITY_INSERT [dbo].[HtmlControl] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] ON;
    EXEC(N'INSERT INTO [dbo].[Role] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Description], [ModifiedByID], [Name])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5160144+08:00'', NULL, N''Administrator'', NULL, N''Administrator''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5160210+08:00'', NULL, N''QA'', NULL, N''QA''),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5160214+08:00'', NULL, N''TL'', NULL, N''TL''),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5160216+08:00'', NULL, N''TM'', NULL, N''TM'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Description', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] ON;
    EXEC(N'INSERT INTO [dbo].[User] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Email], [FirstName], [Key], [LastName], [MiddleName], [ModifiedByID], [Password], [Username])
    VALUES (CAST(14 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178089+08:00'', NULL, N''roel.bernal@email.com'', N''Roel'', ''b89e8918-0952-4546-883d-efb54095619e'', N''Bernal'', N''V'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1605003''),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178086+08:00'', NULL, N''bella.flores@email.com'', N''Bella'', ''a86cd837-1c50-49de-82bd-93203717fe3e'', N''Flores'', N''S'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1605002''),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178084+08:00'', NULL, N''evag.yariv@email.com'', N''Evag'', ''a0215166-0718-4d4f-957c-7a104b533884'', N''Yariv'', N''D'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1605001''),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178082+08:00'', NULL, N''kitty.chicha@email.com'', N''Kitty Chicha'', ''74e8db5d-e9c9-47a1-b793-ba6ccb09c404'', N''Amatayakul'', N''Z'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1605000''),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178079+08:00'', NULL, N''charlie.davao@email.com'', N''Charlie'', ''295bfad2-997f-40af-a50c-b2b76e558a5e'', N''Davao'', N''G'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604999''),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178076+08:00'', NULL, N''max.alvarado@email.com'', N''Max'', ''f472a092-dc4c-4fa3-90d9-5a86eea5aa38'', N''Alvarado'', N''G'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604998''),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178074+08:00'', NULL, N''jimmy.santos@email.com'', N''Ace'', ''4bd2ef61-0fb8-4fa7-a3b9-39c63060336c'', N''Vergel'', N''H'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604997''),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178067+08:00'', NULL, N''dick.israel@email.com'', N''Dick'', ''6b8538a5-5163-4b0d-902f-24b59cc00375'', N''Israel'', N''D'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604994''),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178069+08:00'', NULL, N''rex.cortez@email.com'', N''Rex'', ''edc4150f-2723-4a38-bc59-f6fd1737d236'', N''Cortez'', N''E'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604995''),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178064+08:00'', NULL, N''vic.diaz@email.com'', N''Vic'', ''480dd49e-7bb8-4df1-bd16-c9592f3be5be'', N''Diaz'', N''C'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604990''),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178061+08:00'', NULL, N''romy.diaz@email.com'', N''Romy'', ''73d4794b-76db-4ddd-816c-e8e25f89e756'', N''Diaz'', N''B'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604992''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178057+08:00'', NULL, N''pacquito.diaz@email.com'', N''Pacquito'', ''72b5a528-6838-4dc2-a889-30a47db1ce07'', N''Diaz'', N''B'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604991''),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5177960+08:00'', NULL, N''mcnielv@gmail.com'', N''McNiel'', ''a891cec8-0808-4cde-a42e-495634b0af03'', N''Viray'', N''N'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604993'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] ON;
    EXEC(N'INSERT INTO [dbo].[User] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Email], [FirstName], [Key], [LastName], [MiddleName], [ModifiedByID], [Password], [Username])
    VALUES (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178071+08:00'', NULL, N''ace.vergel@email.com'', N''Jimmy'', ''d5fa1bed-9a40-45f9-8e09-bc2b103e9be6'', N''Santos'', N''F'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1604996'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] ON;
    EXEC(N'INSERT INTO [dbo].[User] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [Email], [FirstName], [Key], [LastName], [MiddleName], [ModifiedByID], [Password], [Username])
    VALUES (CAST(15 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5178091+08:00'', NULL, N''ohdet.khan@email.com'', N''Ohdet'', ''c1007d8c-3d00-4264-b93e-d9e04e420197'', N''Khan'', N''R'', NULL, N''Jaemp2W0c4pSRQ8SMICEvg=='', N''1605004'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'Email', N'FirstName', N'Key', N'LastName', N'MiddleName', N'ModifiedByID', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormCategoryID', N'FormTypeID', N'IsNoteVisible', N'Key', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Form]'))
        SET IDENTITY_INSERT [dbo].[Form] ON;
    EXEC(N'INSERT INTO [dbo].[Form] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormCategoryID], [FormTypeID], [IsNoteVisible], [Key], [ModifiedByID], [Name])
    VALUES (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5250970+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), CAST(1 AS bit), ''73d4794b-76db-4ddd-816c-e8e25f89e756'', NULL, N''QA Form 3''),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5250965+08:00'', NULL, CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bit), ''72b5a528-6838-4dc2-a889-30a47db1ce07'', NULL, N''QA Form 2''),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5250834+08:00'', NULL, CAST(4 AS bigint), CAST(1 AS bigint), CAST(1 AS bit), ''a891cec8-0808-4cde-a42e-495634b0af03'', NULL, N''QA Form 1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormCategoryID', N'FormTypeID', N'IsNoteVisible', N'Key', N'ModifiedByID', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Form]'))
        SET IDENTITY_INSERT [dbo].[Form] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'AppNavigationID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID') AND [object_id] = OBJECT_ID(N'[dbo].[RoleAppNavigation]'))
        SET IDENTITY_INSERT [dbo].[RoleAppNavigation] ON;
    EXEC(N'INSERT INTO [dbo].[RoleAppNavigation] ([ID], [Active], [AppNavigationID], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [RoleID])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230002+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(17 AS bigint), CAST(1 AS bit), CAST(13 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230093+08:00'', NULL, NULL, CAST(4 AS bigint)),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(11 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230081+08:00'', NULL, NULL, CAST(4 AS bigint)),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(10 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230079+08:00'', NULL, NULL, CAST(3 AS bigint)),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(13 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230089+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(12 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230085+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(9 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230076+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(16 AS bigint), CAST(1 AS bit), CAST(13 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230091+08:00'', NULL, NULL, CAST(3 AS bigint)),
    (CAST(7 AS bigint), CAST(1 AS bit), CAST(7 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230072+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230070+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230068+08:00'', NULL, NULL, CAST(2 AS bigint)),
    (CAST(14 AS bigint), CAST(1 AS bit), CAST(13 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230087+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(12 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230083+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230066+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230064+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230060+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(8 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5230074+08:00'', NULL, NULL, CAST(2 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'AppNavigationID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID') AND [object_id] = OBJECT_ID(N'[dbo].[RoleAppNavigation]'))
        SET IDENTITY_INSERT [dbo].[RoleAppNavigation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CampaignID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserCampaign]'))
        SET IDENTITY_INSERT [dbo].[UserCampaign] ON;
    EXEC(N'INSERT INTO [dbo].[UserCampaign] ([ID], [Active], [CampaignID], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [UserID])
    VALUES (CAST(9 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202426+08:00'', NULL, NULL, CAST(8 AS bigint)),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202428+08:00'', NULL, NULL, CAST(9 AS bigint)),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202430+08:00'', NULL, NULL, CAST(10 AS bigint)),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202432+08:00'', NULL, NULL, CAST(11 AS bigint)),
    (CAST(16 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202441+08:00'', NULL, NULL, CAST(15 AS bigint)),
    (CAST(14 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202437+08:00'', NULL, NULL, CAST(13 AS bigint)),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202439+08:00'', NULL, NULL, CAST(14 AS bigint)),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202424+08:00'', NULL, NULL, CAST(7 AS bigint)),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202435+08:00'', NULL, NULL, CAST(12 AS bigint)),
    (CAST(7 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202422+08:00'', NULL, NULL, CAST(6 AS bigint)),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202415+08:00'', NULL, NULL, CAST(3 AS bigint)),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202419+08:00'', NULL, NULL, CAST(5 AS bigint)),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202346+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202407+08:00'', NULL, NULL, CAST(1 AS bigint)),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202417+08:00'', NULL, NULL, CAST(4 AS bigint)),
    (CAST(17 AS bigint), CAST(1 AS bit), CAST(4 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202443+08:00'', NULL, NULL, CAST(15 AS bigint)),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5202412+08:00'', NULL, NULL, CAST(2 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CampaignID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserCampaign]'))
        SET IDENTITY_INSERT [dbo].[UserCampaign] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
        SET IDENTITY_INSERT [dbo].[UserRole] ON;
    EXEC(N'INSERT INTO [dbo].[UserRole] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [RoleID], [UserID])
    VALUES (CAST(14 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188350+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(14 AS bigint)),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188348+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(13 AS bigint)),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188211+08:00'', NULL, NULL, CAST(1 AS bigint), CAST(1 AS bigint)),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188346+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(12 AS bigint)),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188344+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(11 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
        SET IDENTITY_INSERT [dbo].[UserRole] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
        SET IDENTITY_INSERT [dbo].[UserRole] ON;
    EXEC(N'INSERT INTO [dbo].[UserRole] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [RoleID], [UserID])
    VALUES (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188279+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(2 AS bigint)),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188342+08:00'', NULL, NULL, CAST(3 AS bigint), CAST(10 AS bigint)),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188340+08:00'', NULL, NULL, CAST(2 AS bigint), CAST(9 AS bigint)),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188283+08:00'', NULL, NULL, CAST(2 AS bigint), CAST(3 AS bigint)),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188338+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(8 AS bigint)),
    (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188336+08:00'', NULL, NULL, CAST(4 AS bigint), CAST(7 AS bigint)),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188285+08:00'', NULL, NULL, CAST(2 AS bigint), CAST(4 AS bigint)),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188290+08:00'', NULL, NULL, CAST(3 AS bigint), CAST(6 AS bigint)),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188288+08:00'', NULL, NULL, CAST(3 AS bigint), CAST(5 AS bigint)),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5188352+08:00'', NULL, NULL, CAST(2 AS bigint), CAST(15 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'RoleID', N'UserID') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
        SET IDENTITY_INSERT [dbo].[UserRole] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [IsNoteVisible], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(27 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303842+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Date'', 27)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303751+08:00'', NULL, CAST(2 AS bigint), CAST(1 AS bigint), NULL, N''Documentation'', 9),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303753+08:00'', NULL, CAST(2 AS bigint), CAST(1 AS bigint), NULL, N''Process Adherance'', 10),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303755+08:00'', NULL, CAST(2 AS bigint), CAST(1 AS bigint), NULL, N''Transfers and Follow-ups'', 11),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303758+08:00'', NULL, CAST(2 AS bigint), CAST(1 AS bigint), NULL, N''Language, Grammar & Formatting'', 12),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303760+08:00'', NULL, CAST(2 AS bigint), CAST(1 AS bigint), NULL, N''Professional Conduct'', 13)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [IsNoteVisible], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(14 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303762+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Date'', 14),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303765+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Teammate'', 15),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303749+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the resolution provided by the TM?'', 8),
    (CAST(16 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303767+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Case ID'', 16),
    (CAST(18 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303772+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Resolution'', 18),
    (CAST(19 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303774+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Delivery ID'', 19),
    (CAST(20 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303776+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the issue of the Cx?'', 20),
    (CAST(21 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303778+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the resolution provided by the TM?'', 21)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(22 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303781+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), NULL, N''Documentation'', 22),
    (CAST(23 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303783+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), NULL, N''Process Adherance'', 23),
    (CAST(24 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303785+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), NULL, N''Transfers and Follow-ups'', 24)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [IsNoteVisible], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(17 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303770+08:00'', NULL, CAST(3 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Issue'', 17)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(25 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303787+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), NULL, N''Language, Grammar & Formatting'', 25)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [IsNoteVisible], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303746+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the issue of the Cx?'', 7),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303742+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Resolution'', 5),
    (CAST(28 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303844+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Teammate'', 28),
    (CAST(29 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303846+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Case ID'', 29),
    (CAST(30 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303849+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Issue'', 30),
    (CAST(31 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303851+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Resolution'', 31),
    (CAST(32 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303854+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Delivery ID'', 32),
    (CAST(33 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303856+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the issue of the Cx?'', 33),
    (CAST(34 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303858+08:00'', NULL, CAST(1 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''What is the resolution provided by the TM?'', 34),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303744+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Delivery ID'', 6)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(35 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303861+08:00'', NULL, CAST(1 AS bigint), CAST(4 AS bigint), NULL, N''Documentation'', 35),
    (CAST(37 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303865+08:00'', NULL, CAST(1 AS bigint), CAST(4 AS bigint), NULL, N''Transfers and Follow-ups'', 37),
    (CAST(38 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303868+08:00'', NULL, CAST(1 AS bigint), CAST(4 AS bigint), NULL, N''Language, Grammar & Formatting'', 38),
    (CAST(39 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303871+08:00'', NULL, CAST(1 AS bigint), CAST(4 AS bigint), NULL, N''Professional Conduct'', 39)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [IsNoteVisible], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303189+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Date'', 1),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303716+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Teammate'', 2),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303736+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Case ID'', 3),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303739+08:00'', NULL, CAST(2 AS bigint), CAST(3 AS bigint), CAST(1 AS bit), NULL, N''Issue'', 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'IsNoteVisible', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestion] ([ID], [Active], [CreatedByID], [DateCreated], [DateModified], [FormID], [HtmlControlID], [ModifiedByID], [Name], [SortOrder])
    VALUES (CAST(36 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303863+08:00'', NULL, CAST(1 AS bigint), CAST(4 AS bigint), NULL, N''Process Adherance'', 36),
    (CAST(26 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), ''2021-06-05T13:07:13.5303839+08:00'', NULL, CAST(3 AS bigint), CAST(1 AS bigint), NULL, N''Professional Conduct'', 26)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'CreatedByID', N'DateCreated', N'DateModified', N'FormID', N'HtmlControlID', N'ModifiedByID', N'Name', N'SortOrder') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestion]'))
        SET IDENTITY_INSERT [dbo].[FormQuestion] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'ChoiceID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'QuestionID') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestionChoice]'))
        SET IDENTITY_INSERT [dbo].[FormQuestionChoice] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestionChoice] ([ID], [Active], [ChoiceID], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [QuestionID])
    VALUES (CAST(26 AS bigint), CAST(1 AS bit), CAST(31 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336366+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(58 AS bigint), CAST(1 AS bit), CAST(28 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336505+08:00'', NULL, NULL, CAST(39 AS bigint)),
    (CAST(59 AS bigint), CAST(1 AS bit), CAST(29 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336507+08:00'', NULL, NULL, CAST(39 AS bigint)),
    (CAST(60 AS bigint), CAST(1 AS bit), CAST(30 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336509+08:00'', NULL, NULL, CAST(39 AS bigint)),
    (CAST(1 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336243+08:00'', NULL, NULL, CAST(9 AS bigint)),
    (CAST(2 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336316+08:00'', NULL, NULL, CAST(9 AS bigint)),
    (CAST(3 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336319+08:00'', NULL, NULL, CAST(10 AS bigint)),
    (CAST(4 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336321+08:00'', NULL, NULL, CAST(10 AS bigint)),
    (CAST(5 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336323+08:00'', NULL, NULL, CAST(11 AS bigint)),
    (CAST(6 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336325+08:00'', NULL, NULL, CAST(11 AS bigint)),
    (CAST(7 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336327+08:00'', NULL, NULL, CAST(12 AS bigint)),
    (CAST(8 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336329+08:00'', NULL, NULL, CAST(12 AS bigint)),
    (CAST(9 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336331+08:00'', NULL, NULL, CAST(13 AS bigint)),
    (CAST(57 AS bigint), CAST(1 AS bit), CAST(27 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336503+08:00'', NULL, NULL, CAST(39 AS bigint)),
    (CAST(10 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336333+08:00'', NULL, NULL, CAST(13 AS bigint)),
    (CAST(12 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336337+08:00'', NULL, NULL, CAST(22 AS bigint)),
    (CAST(13 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336339+08:00'', NULL, NULL, CAST(22 AS bigint)),
    (CAST(14 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336341+08:00'', NULL, NULL, CAST(23 AS bigint)),
    (CAST(15 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336343+08:00'', NULL, NULL, CAST(23 AS bigint)),
    (CAST(16 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336345+08:00'', NULL, NULL, CAST(23 AS bigint)),
    (CAST(17 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336347+08:00'', NULL, NULL, CAST(24 AS bigint)),
    (CAST(18 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336349+08:00'', NULL, NULL, CAST(24 AS bigint)),
    (CAST(19 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336352+08:00'', NULL, NULL, CAST(24 AS bigint)),
    (CAST(20 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336354+08:00'', NULL, NULL, CAST(25 AS bigint)),
    (CAST(21 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336355+08:00'', NULL, NULL, CAST(25 AS bigint)),
    (CAST(22 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336358+08:00'', NULL, NULL, CAST(25 AS bigint)),
    (CAST(23 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336360+08:00'', NULL, NULL, CAST(26 AS bigint)),
    (CAST(11 AS bigint), CAST(1 AS bit), CAST(1 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336335+08:00'', NULL, NULL, CAST(22 AS bigint)),
    (CAST(56 AS bigint), CAST(1 AS bit), CAST(26 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336501+08:00'', NULL, NULL, CAST(39 AS bigint)),
    (CAST(55 AS bigint), CAST(1 AS bit), CAST(25 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336499+08:00'', NULL, NULL, CAST(38 AS bigint)),
    (CAST(54 AS bigint), CAST(1 AS bit), CAST(24 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336497+08:00'', NULL, NULL, CAST(38 AS bigint)),
    (CAST(27 AS bigint), CAST(1 AS bit), CAST(32 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336368+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(28 AS bigint), CAST(1 AS bit), CAST(33 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336370+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(29 AS bigint), CAST(1 AS bit), CAST(34 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336445+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(30 AS bigint), CAST(1 AS bit), CAST(35 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336448+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(31 AS bigint), CAST(1 AS bit), CAST(36 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336449+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(32 AS bigint), CAST(1 AS bit), CAST(37 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336451+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(33 AS bigint), CAST(1 AS bit), CAST(38 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336453+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(34 AS bigint), CAST(1 AS bit), CAST(39 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336455+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(35 AS bigint), CAST(1 AS bit), CAST(40 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336458+08:00'', NULL, NULL, CAST(35 AS bigint)),
    (CAST(36 AS bigint), CAST(1 AS bit), CAST(6 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336460+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(37 AS bigint), CAST(1 AS bit), CAST(7 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336462+08:00'', NULL, NULL, CAST(36 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'ChoiceID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'QuestionID') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestionChoice]'))
        SET IDENTITY_INSERT [dbo].[FormQuestionChoice] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'ChoiceID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'QuestionID') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestionChoice]'))
        SET IDENTITY_INSERT [dbo].[FormQuestionChoice] ON;
    EXEC(N'INSERT INTO [dbo].[FormQuestionChoice] ([ID], [Active], [ChoiceID], [CreatedByID], [DateCreated], [DateModified], [ModifiedByID], [QuestionID])
    VALUES (CAST(38 AS bigint), CAST(1 AS bit), CAST(8 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336463+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(39 AS bigint), CAST(1 AS bit), CAST(9 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336465+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(40 AS bigint), CAST(1 AS bit), CAST(10 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336467+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(41 AS bigint), CAST(1 AS bit), CAST(11 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336470+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(42 AS bigint), CAST(1 AS bit), CAST(12 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336472+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(43 AS bigint), CAST(1 AS bit), CAST(13 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336474+08:00'', NULL, NULL, CAST(36 AS bigint)),
    (CAST(44 AS bigint), CAST(1 AS bit), CAST(14 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336476+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(45 AS bigint), CAST(1 AS bit), CAST(15 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336478+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(46 AS bigint), CAST(1 AS bit), CAST(16 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336480+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(47 AS bigint), CAST(1 AS bit), CAST(17 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336482+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(48 AS bigint), CAST(1 AS bit), CAST(18 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336485+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(49 AS bigint), CAST(1 AS bit), CAST(19 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336487+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(50 AS bigint), CAST(1 AS bit), CAST(20 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336489+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(51 AS bigint), CAST(1 AS bit), CAST(21 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336491+08:00'', NULL, NULL, CAST(37 AS bigint)),
    (CAST(52 AS bigint), CAST(1 AS bit), CAST(22 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336493+08:00'', NULL, NULL, CAST(38 AS bigint)),
    (CAST(53 AS bigint), CAST(1 AS bit), CAST(23 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336495+08:00'', NULL, NULL, CAST(38 AS bigint)),
    (CAST(24 AS bigint), CAST(1 AS bit), CAST(2 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336362+08:00'', NULL, NULL, CAST(26 AS bigint)),
    (CAST(25 AS bigint), CAST(1 AS bit), CAST(3 AS bigint), CAST(1 AS bigint), ''2021-06-05T13:07:13.5336364+08:00'', NULL, NULL, CAST(26 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Active', N'ChoiceID', N'CreatedByID', N'DateCreated', N'DateModified', N'ModifiedByID', N'QuestionID') AND [object_id] = OBJECT_ID(N'[dbo].[FormQuestionChoice]'))
        SET IDENTITY_INSERT [dbo].[FormQuestionChoice] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE UNIQUE INDEX [IX_AppNavigation_Name] ON [dbo].[AppNavigation] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Audit_CreatedByID] ON [dbo].[Audit] ([CreatedByID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Audit_FormID] ON [dbo].[Audit] ([FormID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Audit_TeammateID] ON [dbo].[Audit] ([TeammateID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_AuditDetail_AuditID] ON [dbo].[AuditDetail] ([AuditID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_AuditDetail_ChoiceID] ON [dbo].[AuditDetail] ([ChoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_AuditDetail_QuestionID] ON [dbo].[AuditDetail] ([QuestionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_AuditDetail_UserID] ON [dbo].[AuditDetail] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Form_CreatedByID] ON [dbo].[Form] ([CreatedByID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Form_FormCategoryID] ON [dbo].[Form] ([FormCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Form_FormTypeID] ON [dbo].[Form] ([FormTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_FormQuestion_FormID] ON [dbo].[FormQuestion] ([FormID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_FormQuestion_HtmlControlID] ON [dbo].[FormQuestion] ([HtmlControlID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_FormQuestionChoice_ChoiceID] ON [dbo].[FormQuestionChoice] ([ChoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_FormQuestionChoice_QuestionID] ON [dbo].[FormQuestionChoice] ([QuestionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_HtmlControl_FormCategoryID] ON [dbo].[HtmlControl] ([FormCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_HtmlControl_FormTypeID] ON [dbo].[HtmlControl] ([FormTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_Lob_CampaignID] ON [dbo].[Lob] ([CampaignID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_RefreshToken_UserID] ON [dbo].[RefreshToken] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Role_Name] ON [dbo].[Role] ([Name]) WHERE [Name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_RoleAppNavigation_AppNavigationID] ON [dbo].[RoleAppNavigation] ([AppNavigationID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_RoleAppNavigation_RoleID] ON [dbo].[RoleAppNavigation] ([RoleID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_User_Email] ON [dbo].[User] ([Email]) WHERE [Email] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE UNIQUE INDEX [IX_User_Username] ON [dbo].[User] ([Username]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_UserCampaign_CampaignID] ON [dbo].[UserCampaign] ([CampaignID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_UserCampaign_UserID] ON [dbo].[UserCampaign] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_UserRole_RoleID] ON [dbo].[UserRole] ([RoleID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    CREATE INDEX [IX_UserRole_UserID] ON [dbo].[UserRole] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605050714_InitialBuild')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210605050714_InitialBuild', N'5.0.4');
END;
GO

COMMIT;
GO

