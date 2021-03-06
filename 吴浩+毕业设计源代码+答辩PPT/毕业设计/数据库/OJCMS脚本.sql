USE [OJCMS]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NavigateUrl] [nvarchar](max) NULL,
	[Target] [nvarchar](max) NULL,
	[Id_perent] [bigint] NULL,
	[InnerCode] [nvarchar](max) NULL,
	[Ds] [bit] NOT NULL,
	[Fg_sys] [bit] NOT NULL,
	[Num] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Pwd] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Age] [int] NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](max) NULL,
	[Ds] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionAssignment]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Menu] [bigint] NOT NULL,
	[Id_Permission] [bigint] NOT NULL,
 CONSTRAINT [PK_PermissionAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[URAssignmentDO]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[URAssignmentDO](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_User] [bigint] NOT NULL,
	[Id_Role] [bigint] NOT NULL,
 CONSTRAINT [PK_URAssignmentDO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UPAssignment]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UPAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_User] [bigint] NOT NULL,
	[Id_Permission] [bigint] NOT NULL,
 CONSTRAINT [PK_UPAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UGAssignmentDO]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UGAssignmentDO](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_User] [bigint] NOT NULL,
	[Id_UserGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_UGAssignmentDO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RPAssignment]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Role] [bigint] NOT NULL,
	[Id_Per] [bigint] NOT NULL,
 CONSTRAINT [PK_RPAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GPAssignment]    Script Date: 05/30/2016 11:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_UserGroup] [bigint] NOT NULL,
	[Id_Permission] [bigint] NOT NULL,
 CONSTRAINT [PK_GPAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_GPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[GPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_GPAssignmentDOPermissionDO] FOREIGN KEY([Id_Permission])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[GPAssignment] CHECK CONSTRAINT [FK_GPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_GPAssignmentDOUserGroupDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[GPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_GPAssignmentDOUserGroupDO] FOREIGN KEY([Id_UserGroup])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[GPAssignment] CHECK CONSTRAINT [FK_GPAssignmentDOUserGroupDO]
GO
/****** Object:  ForeignKey [FK_PermissionAssignmentDOMenuDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[PermissionAssignment]  WITH CHECK ADD  CONSTRAINT [FK_PermissionAssignmentDOMenuDO] FOREIGN KEY([Id_Menu])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[PermissionAssignment] CHECK CONSTRAINT [FK_PermissionAssignmentDOMenuDO]
GO
/****** Object:  ForeignKey [FK_PermissionAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[PermissionAssignment]  WITH CHECK ADD  CONSTRAINT [FK_PermissionAssignmentDOPermissionDO] FOREIGN KEY([Id_Permission])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[PermissionAssignment] CHECK CONSTRAINT [FK_PermissionAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_RPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[RPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RPAssignmentDOPermissionDO] FOREIGN KEY([Id_Per])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[RPAssignment] CHECK CONSTRAINT [FK_RPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_RPAssignmentDORoleDo]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[RPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RPAssignmentDORoleDo] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RPAssignment] CHECK CONSTRAINT [FK_RPAssignmentDORoleDo]
GO
/****** Object:  ForeignKey [FK_UGAssignmentDOUserDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[UGAssignmentDO]  WITH CHECK ADD  CONSTRAINT [FK_UGAssignmentDOUserDO] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UGAssignmentDO] CHECK CONSTRAINT [FK_UGAssignmentDOUserDO]
GO
/****** Object:  ForeignKey [FK_UGAssignmentDOUserGroupDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[UGAssignmentDO]  WITH CHECK ADD  CONSTRAINT [FK_UGAssignmentDOUserGroupDO] FOREIGN KEY([Id_UserGroup])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[UGAssignmentDO] CHECK CONSTRAINT [FK_UGAssignmentDOUserGroupDO]
GO
/****** Object:  ForeignKey [FK_UPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[UPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UPAssignmentDOPermissionDO] FOREIGN KEY([Id_Permission])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[UPAssignment] CHECK CONSTRAINT [FK_UPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_UPAssignmentDOUserDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[UPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UPAssignmentDOUserDO] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UPAssignment] CHECK CONSTRAINT [FK_UPAssignmentDOUserDO]
GO
/****** Object:  ForeignKey [FK_URAssignmentDORoleDo]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[URAssignmentDO]  WITH CHECK ADD  CONSTRAINT [FK_URAssignmentDORoleDo] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[URAssignmentDO] CHECK CONSTRAINT [FK_URAssignmentDORoleDo]
GO
/****** Object:  ForeignKey [FK_UserDOURAssignmentDO]    Script Date: 05/30/2016 11:21:20 ******/
ALTER TABLE [dbo].[URAssignmentDO]  WITH CHECK ADD  CONSTRAINT [FK_UserDOURAssignmentDO] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[URAssignmentDO] CHECK CONSTRAINT [FK_UserDOURAssignmentDO]
GO
