
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2016 13:20:59
-- Generated from EDMX file: D:\个人文件夹\SVN\本地\bysj\OJ\OJ.Domain\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OJ];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_problemsolution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Solution] DROP CONSTRAINT [FK_problemsolution];
GO
IF OBJECT_ID(N'[dbo].[FK_solutionsourceCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SourceCode] DROP CONSTRAINT [FK_solutionsourceCode];
GO
IF OBJECT_ID(N'[dbo].[FK_usersolution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Solution] DROP CONSTRAINT [FK_usersolution];
GO
IF OBJECT_ID(N'[dbo].[FK_languageuser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_languageuser];
GO
IF OBJECT_ID(N'[dbo].[FK_languagesolution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Solution] DROP CONSTRAINT [FK_languagesolution];
GO
IF OBJECT_ID(N'[dbo].[FK_userloginlog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Loginlog] DROP CONSTRAINT [FK_userloginlog];
GO
IF OBJECT_ID(N'[dbo].[FK_UGAssignmentDOUserGroupDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UGAssignment] DROP CONSTRAINT [FK_UGAssignmentDOUserGroupDO];
GO
IF OBJECT_ID(N'[dbo].[FK_GPAssignmentDOUserGroupDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GPAssignment] DROP CONSTRAINT [FK_GPAssignmentDOUserGroupDO];
GO
IF OBJECT_ID(N'[dbo].[FK_RPAssignmentDORoleDo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RPAssignment] DROP CONSTRAINT [FK_RPAssignmentDORoleDo];
GO
IF OBJECT_ID(N'[dbo].[FK_URAssignmentDORoleDo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[URAssignment] DROP CONSTRAINT [FK_URAssignmentDORoleDo];
GO
IF OBJECT_ID(N'[dbo].[FK_RPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RPAssignment] DROP CONSTRAINT [FK_RPAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_GPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GPAssignment] DROP CONSTRAINT [FK_GPAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPAssignment] DROP CONSTRAINT [FK_UPAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUPAssignmentDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPAssignment] DROP CONSTRAINT [FK_UserUPAssignmentDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UGAssignmentDOUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UGAssignment] DROP CONSTRAINT [FK_UGAssignmentDOUser];
GO
IF OBJECT_ID(N'[dbo].[FK_URAssignmentDOUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[URAssignment] DROP CONSTRAINT [FK_URAssignmentDOUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Problem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Problem];
GO
IF OBJECT_ID(N'[dbo].[Solution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Solution];
GO
IF OBJECT_ID(N'[dbo].[SourceCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SourceCode];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[Loginlog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loginlog];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[RPAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RPAssignment];
GO
IF OBJECT_ID(N'[dbo].[URAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[URAssignment];
GO
IF OBJECT_ID(N'[dbo].[UGAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UGAssignment];
GO
IF OBJECT_ID(N'[dbo].[GPAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GPAssignment];
GO
IF OBJECT_ID(N'[dbo].[UPAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UPAssignment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Problem'
CREATE TABLE [dbo].[Problem] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Describe] nvarchar(max)  NOT NULL,
    [Input] nvarchar(max)  NOT NULL,
    [Output] nvarchar(max)  NOT NULL,
    [Sample_input] nvarchar(max)  NOT NULL,
    [Sample_output] nvarchar(max)  NOT NULL,
    [Fg_special] nvarchar(max)  NULL,
    [Hint] nvarchar(max)  NULL,
    [Source] nvarchar(max)  NULL,
    [In_date] datetime  NOT NULL,
    [Time_limit] int  NOT NULL,
    [Memory_limit] int  NOT NULL,
    [Defunct] bit  NOT NULL,
    [Accepted] bigint  NULL,
    [Submit] bigint  NULL,
    [Solved] int  NULL,
    [Difficulty] nvarchar(max)  NOT NULL,
    [Uploader] bigint  NOT NULL
);
GO

-- Creating table 'Solution'
CREATE TABLE [dbo].[Solution] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [id_problem] bigint  NOT NULL,
    [id_user] bigint  NOT NULL,
    [time] int  NULL,
    [memory] int  NULL,
    [createTime] datetimeoffset  NULL,
    [result] int  NULL,
    [id_language] int  NOT NULL,
    [userIp] nvarchar(max)  NULL,
    [codeLenght] nvarchar(max)  NULL,
    [judgeTime] datetime  NULL,
    [pass_rate] nvarchar(max)  NULL,
    [id_contest] nvarchar(max)  NULL,
    [valid] bit  NULL,
    [num] int  NULL
);
GO

-- Creating table 'SourceCode'
CREATE TABLE [dbo].[SourceCode] (
    [Id_solution] bigint  NOT NULL,
    [Source_code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Submit] bigint  NULL,
    [Solved] bigint  NULL,
    [RegTime] datetime  NULL,
    [AccessTime] datetime  NULL,
    [RegIp] nvarchar(max)  NULL,
    [AccessIp] nvarchar(max)  NULL,
    [Defunct] bit  NULL,
    [School] nvarchar(max)  NULL,
    [Id_language] int  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Age] int  NULL,
    [Birthday] datetime  NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- Creating table 'Language'
CREATE TABLE [dbo].[Language] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Loginlog'
CREATE TABLE [dbo].[Loginlog] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [id_user] bigint  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [ip] nvarchar(max)  NOT NULL,
    [logintime] datetime  NOT NULL
);
GO

-- Creating table 'UserGroup'
CREATE TABLE [dbo].[UserGroup] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RPAssignment'
CREATE TABLE [dbo].[RPAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_Role] bigint  NOT NULL,
    [Id_Per] bigint  NOT NULL
);
GO

-- Creating table 'URAssignment'
CREATE TABLE [dbo].[URAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_User] bigint  NOT NULL,
    [Id_Role] bigint  NOT NULL
);
GO

-- Creating table 'UGAssignment'
CREATE TABLE [dbo].[UGAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_User] bigint  NOT NULL,
    [Id_UserGroup] bigint  NOT NULL
);
GO

-- Creating table 'GPAssignment'
CREATE TABLE [dbo].[GPAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_UserGroup] bigint  NOT NULL,
    [Id_Permission] bigint  NOT NULL
);
GO

-- Creating table 'UPAssignment'
CREATE TABLE [dbo].[UPAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_User] bigint  NOT NULL,
    [Id_Permission] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Problem'
ALTER TABLE [dbo].[Problem]
ADD CONSTRAINT [PK_Problem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Solution'
ALTER TABLE [dbo].[Solution]
ADD CONSTRAINT [PK_Solution]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id_solution] in table 'SourceCode'
ALTER TABLE [dbo].[SourceCode]
ADD CONSTRAINT [PK_SourceCode]
    PRIMARY KEY CLUSTERED ([Id_solution] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Language'
ALTER TABLE [dbo].[Language]
ADD CONSTRAINT [PK_Language]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Loginlog'
ALTER TABLE [dbo].[Loginlog]
ADD CONSTRAINT [PK_Loginlog]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [PK_UserGroup]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'RPAssignment'
ALTER TABLE [dbo].[RPAssignment]
ADD CONSTRAINT [PK_RPAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'URAssignment'
ALTER TABLE [dbo].[URAssignment]
ADD CONSTRAINT [PK_URAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UGAssignment'
ALTER TABLE [dbo].[UGAssignment]
ADD CONSTRAINT [PK_UGAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GPAssignment'
ALTER TABLE [dbo].[GPAssignment]
ADD CONSTRAINT [PK_GPAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UPAssignment'
ALTER TABLE [dbo].[UPAssignment]
ADD CONSTRAINT [PK_UPAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_problem] in table 'Solution'
ALTER TABLE [dbo].[Solution]
ADD CONSTRAINT [FK_problemsolution]
    FOREIGN KEY ([id_problem])
    REFERENCES [dbo].[Problem]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_problemsolution'
CREATE INDEX [IX_FK_problemsolution]
ON [dbo].[Solution]
    ([id_problem]);
GO

-- Creating foreign key on [Id_solution] in table 'SourceCode'
ALTER TABLE [dbo].[SourceCode]
ADD CONSTRAINT [FK_solutionsourceCode]
    FOREIGN KEY ([Id_solution])
    REFERENCES [dbo].[Solution]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_user] in table 'Solution'
ALTER TABLE [dbo].[Solution]
ADD CONSTRAINT [FK_usersolution]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usersolution'
CREATE INDEX [IX_FK_usersolution]
ON [dbo].[Solution]
    ([id_user]);
GO

-- Creating foreign key on [Id_language] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_languageuser]
    FOREIGN KEY ([Id_language])
    REFERENCES [dbo].[Language]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_languageuser'
CREATE INDEX [IX_FK_languageuser]
ON [dbo].[User]
    ([Id_language]);
GO

-- Creating foreign key on [id_language] in table 'Solution'
ALTER TABLE [dbo].[Solution]
ADD CONSTRAINT [FK_languagesolution]
    FOREIGN KEY ([id_language])
    REFERENCES [dbo].[Language]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_languagesolution'
CREATE INDEX [IX_FK_languagesolution]
ON [dbo].[Solution]
    ([id_language]);
GO

-- Creating foreign key on [id_user] in table 'Loginlog'
ALTER TABLE [dbo].[Loginlog]
ADD CONSTRAINT [FK_userloginlog]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_userloginlog'
CREATE INDEX [IX_FK_userloginlog]
ON [dbo].[Loginlog]
    ([id_user]);
GO

-- Creating foreign key on [Id_UserGroup] in table 'UGAssignment'
ALTER TABLE [dbo].[UGAssignment]
ADD CONSTRAINT [FK_UGAssignmentDOUserGroupDO]
    FOREIGN KEY ([Id_UserGroup])
    REFERENCES [dbo].[UserGroup]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UGAssignmentDOUserGroupDO'
CREATE INDEX [IX_FK_UGAssignmentDOUserGroupDO]
ON [dbo].[UGAssignment]
    ([Id_UserGroup]);
GO

-- Creating foreign key on [Id_UserGroup] in table 'GPAssignment'
ALTER TABLE [dbo].[GPAssignment]
ADD CONSTRAINT [FK_GPAssignmentDOUserGroupDO]
    FOREIGN KEY ([Id_UserGroup])
    REFERENCES [dbo].[UserGroup]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GPAssignmentDOUserGroupDO'
CREATE INDEX [IX_FK_GPAssignmentDOUserGroupDO]
ON [dbo].[GPAssignment]
    ([Id_UserGroup]);
GO

-- Creating foreign key on [Id_Role] in table 'RPAssignment'
ALTER TABLE [dbo].[RPAssignment]
ADD CONSTRAINT [FK_RPAssignmentDORoleDo]
    FOREIGN KEY ([Id_Role])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RPAssignmentDORoleDo'
CREATE INDEX [IX_FK_RPAssignmentDORoleDo]
ON [dbo].[RPAssignment]
    ([Id_Role]);
GO

-- Creating foreign key on [Id_Role] in table 'URAssignment'
ALTER TABLE [dbo].[URAssignment]
ADD CONSTRAINT [FK_URAssignmentDORoleDo]
    FOREIGN KEY ([Id_Role])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_URAssignmentDORoleDo'
CREATE INDEX [IX_FK_URAssignmentDORoleDo]
ON [dbo].[URAssignment]
    ([Id_Role]);
GO

-- Creating foreign key on [Id_Per] in table 'RPAssignment'
ALTER TABLE [dbo].[RPAssignment]
ADD CONSTRAINT [FK_RPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Per])
    REFERENCES [dbo].[Permission]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_RPAssignmentDOPermissionDO]
ON [dbo].[RPAssignment]
    ([Id_Per]);
GO

-- Creating foreign key on [Id_Permission] in table 'GPAssignment'
ALTER TABLE [dbo].[GPAssignment]
ADD CONSTRAINT [FK_GPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Permission])
    REFERENCES [dbo].[Permission]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_GPAssignmentDOPermissionDO]
ON [dbo].[GPAssignment]
    ([Id_Permission]);
GO

-- Creating foreign key on [Id_Permission] in table 'UPAssignment'
ALTER TABLE [dbo].[UPAssignment]
ADD CONSTRAINT [FK_UPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Permission])
    REFERENCES [dbo].[Permission]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_UPAssignmentDOPermissionDO]
ON [dbo].[UPAssignment]
    ([Id_Permission]);
GO

-- Creating foreign key on [Id_User] in table 'UPAssignment'
ALTER TABLE [dbo].[UPAssignment]
ADD CONSTRAINT [FK_UserUPAssignmentDO]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUPAssignmentDO'
CREATE INDEX [IX_FK_UserUPAssignmentDO]
ON [dbo].[UPAssignment]
    ([Id_User]);
GO

-- Creating foreign key on [Id_User] in table 'UGAssignment'
ALTER TABLE [dbo].[UGAssignment]
ADD CONSTRAINT [FK_UGAssignmentDOUser]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UGAssignmentDOUser'
CREATE INDEX [IX_FK_UGAssignmentDOUser]
ON [dbo].[UGAssignment]
    ([Id_User]);
GO

-- Creating foreign key on [Id_User] in table 'URAssignment'
ALTER TABLE [dbo].[URAssignment]
ADD CONSTRAINT [FK_URAssignmentDOUser]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_URAssignmentDOUser'
CREATE INDEX [IX_FK_URAssignmentDOUser]
ON [dbo].[URAssignment]
    ([Id_User]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------