
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2016 20:04:30
-- Generated from EDMX file: D:\个人文件夹\SVN\OJCMS\OJCMS.Domain\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OJCMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RPAssignmentDORoleDo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RPAssignment] DROP CONSTRAINT [FK_RPAssignmentDORoleDo];
GO
IF OBJECT_ID(N'[dbo].[FK_RPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RPAssignment] DROP CONSTRAINT [FK_RPAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDOURAssignmentDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[URAssignmentDO] DROP CONSTRAINT [FK_UserDOURAssignmentDO];
GO
IF OBJECT_ID(N'[dbo].[FK_URAssignmentDORoleDo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[URAssignmentDO] DROP CONSTRAINT [FK_URAssignmentDORoleDo];
GO
IF OBJECT_ID(N'[dbo].[FK_UGAssignmentDOUserDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UGAssignmentDO] DROP CONSTRAINT [FK_UGAssignmentDOUserDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UGAssignmentDOUserGroupDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UGAssignmentDO] DROP CONSTRAINT [FK_UGAssignmentDOUserGroupDO];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissionAssignment] DROP CONSTRAINT [FK_PermissionAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionAssignmentDOMenuDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissionAssignment] DROP CONSTRAINT [FK_PermissionAssignmentDOMenuDO];
GO
IF OBJECT_ID(N'[dbo].[FK_GPAssignmentDOUserGroupDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GPAssignment] DROP CONSTRAINT [FK_GPAssignmentDOUserGroupDO];
GO
IF OBJECT_ID(N'[dbo].[FK_GPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GPAssignment] DROP CONSTRAINT [FK_GPAssignmentDOPermissionDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UPAssignmentDOUserDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPAssignment] DROP CONSTRAINT [FK_UPAssignmentDOUserDO];
GO
IF OBJECT_ID(N'[dbo].[FK_UPAssignmentDOPermissionDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPAssignment] DROP CONSTRAINT [FK_UPAssignmentDOPermissionDO];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menu];
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
IF OBJECT_ID(N'[dbo].[URAssignmentDO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[URAssignmentDO];
GO
IF OBJECT_ID(N'[dbo].[UGAssignmentDO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UGAssignmentDO];
GO
IF OBJECT_ID(N'[dbo].[PermissionAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissionAssignment];
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

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] bigint  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Pwd] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NULL,
    [Birthday] datetime  NULL,
    [Address] nvarchar(max)  NULL,
    [Ds] bit  NOT NULL
);
GO

-- Creating table 'Menu'
CREATE TABLE [dbo].[Menu] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NavigateUrl] nvarchar(max)  NULL,
    [Target] nvarchar(max)  NULL,
    [Id_perent] bigint  NULL,
    [InnerCode] nvarchar(max)  NULL,
    [Ds] bit  NOT NULL,
    [Fg_sys] bit  NOT NULL,
    [Num] int  NULL
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
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RPAssignment'
CREATE TABLE [dbo].[RPAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_Role] bigint  NOT NULL,
    [Id_Per] bigint  NOT NULL
);
GO

-- Creating table 'URAssignmentDO'
CREATE TABLE [dbo].[URAssignmentDO] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_User] bigint  NOT NULL,
    [Id_Role] bigint  NOT NULL
);
GO

-- Creating table 'UGAssignmentDO'
CREATE TABLE [dbo].[UGAssignmentDO] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_User] bigint  NOT NULL,
    [Id_UserGroup] bigint  NOT NULL
);
GO

-- Creating table 'PermissionAssignment'
CREATE TABLE [dbo].[PermissionAssignment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Id_Menu] bigint  NOT NULL,
    [Id_Permission] bigint  NOT NULL
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

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [PK_Menu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RPAssignment'
ALTER TABLE [dbo].[RPAssignment]
ADD CONSTRAINT [PK_RPAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'URAssignmentDO'
ALTER TABLE [dbo].[URAssignmentDO]
ADD CONSTRAINT [PK_URAssignmentDO]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UGAssignmentDO'
ALTER TABLE [dbo].[UGAssignmentDO]
ADD CONSTRAINT [PK_UGAssignmentDO]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermissionAssignment'
ALTER TABLE [dbo].[PermissionAssignment]
ADD CONSTRAINT [PK_PermissionAssignment]
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

-- Creating foreign key on [Id_Per] in table 'RPAssignment'
ALTER TABLE [dbo].[RPAssignment]
ADD CONSTRAINT [FK_RPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Per])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_RPAssignmentDOPermissionDO]
ON [dbo].[RPAssignment]
    ([Id_Per]);
GO

-- Creating foreign key on [Id_User] in table 'URAssignmentDO'
ALTER TABLE [dbo].[URAssignmentDO]
ADD CONSTRAINT [FK_UserDOURAssignmentDO]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDOURAssignmentDO'
CREATE INDEX [IX_FK_UserDOURAssignmentDO]
ON [dbo].[URAssignmentDO]
    ([Id_User]);
GO

-- Creating foreign key on [Id_Role] in table 'URAssignmentDO'
ALTER TABLE [dbo].[URAssignmentDO]
ADD CONSTRAINT [FK_URAssignmentDORoleDo]
    FOREIGN KEY ([Id_Role])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_URAssignmentDORoleDo'
CREATE INDEX [IX_FK_URAssignmentDORoleDo]
ON [dbo].[URAssignmentDO]
    ([Id_Role]);
GO

-- Creating foreign key on [Id_User] in table 'UGAssignmentDO'
ALTER TABLE [dbo].[UGAssignmentDO]
ADD CONSTRAINT [FK_UGAssignmentDOUserDO]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UGAssignmentDOUserDO'
CREATE INDEX [IX_FK_UGAssignmentDOUserDO]
ON [dbo].[UGAssignmentDO]
    ([Id_User]);
GO

-- Creating foreign key on [Id_UserGroup] in table 'UGAssignmentDO'
ALTER TABLE [dbo].[UGAssignmentDO]
ADD CONSTRAINT [FK_UGAssignmentDOUserGroupDO]
    FOREIGN KEY ([Id_UserGroup])
    REFERENCES [dbo].[UserGroup]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UGAssignmentDOUserGroupDO'
CREATE INDEX [IX_FK_UGAssignmentDOUserGroupDO]
ON [dbo].[UGAssignmentDO]
    ([Id_UserGroup]);
GO

-- Creating foreign key on [Id_Permission] in table 'PermissionAssignment'
ALTER TABLE [dbo].[PermissionAssignment]
ADD CONSTRAINT [FK_PermissionAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Permission])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PermissionAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_PermissionAssignmentDOPermissionDO]
ON [dbo].[PermissionAssignment]
    ([Id_Permission]);
GO

-- Creating foreign key on [Id_Menu] in table 'PermissionAssignment'
ALTER TABLE [dbo].[PermissionAssignment]
ADD CONSTRAINT [FK_PermissionAssignmentDOMenuDO]
    FOREIGN KEY ([Id_Menu])
    REFERENCES [dbo].[Menu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PermissionAssignmentDOMenuDO'
CREATE INDEX [IX_FK_PermissionAssignmentDOMenuDO]
ON [dbo].[PermissionAssignment]
    ([Id_Menu]);
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

-- Creating foreign key on [Id_Permission] in table 'GPAssignment'
ALTER TABLE [dbo].[GPAssignment]
ADD CONSTRAINT [FK_GPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Permission])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_GPAssignmentDOPermissionDO]
ON [dbo].[GPAssignment]
    ([Id_Permission]);
GO

-- Creating foreign key on [Id_User] in table 'UPAssignment'
ALTER TABLE [dbo].[UPAssignment]
ADD CONSTRAINT [FK_UPAssignmentDOUserDO]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UPAssignmentDOUserDO'
CREATE INDEX [IX_FK_UPAssignmentDOUserDO]
ON [dbo].[UPAssignment]
    ([Id_User]);
GO

-- Creating foreign key on [Id_Permission] in table 'UPAssignment'
ALTER TABLE [dbo].[UPAssignment]
ADD CONSTRAINT [FK_UPAssignmentDOPermissionDO]
    FOREIGN KEY ([Id_Permission])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UPAssignmentDOPermissionDO'
CREATE INDEX [IX_FK_UPAssignmentDOPermissionDO]
ON [dbo].[UPAssignment]
    ([Id_Permission]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------