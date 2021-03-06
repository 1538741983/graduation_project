USE [OJ]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/30/2016 11:19:31 ******/
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
/****** Object:  Table [dbo].[Problem]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Describe] [nvarchar](max) NOT NULL,
	[Input] [nvarchar](max) NOT NULL,
	[Output] [nvarchar](max) NOT NULL,
	[Sample_input] [nvarchar](max) NOT NULL,
	[Sample_output] [nvarchar](max) NOT NULL,
	[Fg_special] [nvarchar](max) NULL,
	[Hint] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[In_date] [datetime] NOT NULL,
	[Time_limit] [int] NOT NULL,
	[Memory_limit] [int] NOT NULL,
	[Defunct] [bit] NOT NULL,
	[Accepted] [bigint] NULL,
	[Submit] [bigint] NULL,
	[Solved] [int] NULL,
	[Difficulty] [nvarchar](max) NOT NULL,
	[Uploader] [bigint] NOT NULL,
 CONSTRAINT [PK_Problem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 05/30/2016 11:19:31 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Submit] [bigint] NULL,
	[Solved] [bigint] NULL,
	[RegTime] [datetime] NULL,
	[AccessTime] [datetime] NULL,
	[RegIp] [nvarchar](max) NULL,
	[AccessIp] [nvarchar](max) NULL,
	[Defunct] [bit] NULL,
	[School] [nvarchar](max) NULL,
	[Id_language] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Age] [int] NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GPAssignment]    Script Date: 05/30/2016 11:19:31 ******/
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
/****** Object:  Table [dbo].[RPAssignment]    Script Date: 05/30/2016 11:19:31 ******/
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
/****** Object:  Table [dbo].[Solution]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solution](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_problem] [bigint] NOT NULL,
	[id_user] [bigint] NOT NULL,
	[time] [int] NULL,
	[memory] [int] NULL,
	[createTime] [datetimeoffset](7) NULL,
	[result] [nvarchar](max) NULL,
	[id_language] [int] NOT NULL,
	[userIp] [nvarchar](max) NULL,
	[codeLenght] [nvarchar](max) NULL,
	[judgeTime] [datetime] NULL,
	[pass_rate] [nvarchar](max) NULL,
	[id_contest] [nvarchar](max) NULL,
	[valid] [bit] NULL,
	[num] [int] NULL,
 CONSTRAINT [PK_Solution] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loginlog]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loginlog](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_user] [bigint] NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[ip] [nvarchar](max) NOT NULL,
	[logintime] [datetime] NOT NULL,
 CONSTRAINT [PK_Loginlog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[URAssignment]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[URAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_User] [bigint] NOT NULL,
	[Id_Role] [bigint] NOT NULL,
 CONSTRAINT [PK_URAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UPAssignment]    Script Date: 05/30/2016 11:19:31 ******/
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
/****** Object:  Table [dbo].[UGAssignment]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UGAssignment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_User] [bigint] NOT NULL,
	[Id_UserGroup] [bigint] NOT NULL,
 CONSTRAINT [PK_UGAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceCode]    Script Date: 05/30/2016 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceCode](
	[Id_solution] [bigint] NOT NULL,
	[Source_code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SourceCode] PRIMARY KEY CLUSTERED 
(
	[Id_solution] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_GPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[GPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_GPAssignmentDOPermissionDO] FOREIGN KEY([Id_Permission])
REFERENCES [dbo].[Permission] ([id])
GO
ALTER TABLE [dbo].[GPAssignment] CHECK CONSTRAINT [FK_GPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_GPAssignmentDOUserGroupDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[GPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_GPAssignmentDOUserGroupDO] FOREIGN KEY([Id_UserGroup])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[GPAssignment] CHECK CONSTRAINT [FK_GPAssignmentDOUserGroupDO]
GO
/****** Object:  ForeignKey [FK_userloginlog]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[Loginlog]  WITH CHECK ADD  CONSTRAINT [FK_userloginlog] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Loginlog] CHECK CONSTRAINT [FK_userloginlog]
GO
/****** Object:  ForeignKey [FK_RPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[RPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RPAssignmentDOPermissionDO] FOREIGN KEY([Id_Per])
REFERENCES [dbo].[Permission] ([id])
GO
ALTER TABLE [dbo].[RPAssignment] CHECK CONSTRAINT [FK_RPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_RPAssignmentDORoleDo]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[RPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RPAssignmentDORoleDo] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RPAssignment] CHECK CONSTRAINT [FK_RPAssignmentDORoleDo]
GO
/****** Object:  ForeignKey [FK_languagesolution]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[Solution]  WITH CHECK ADD  CONSTRAINT [FK_languagesolution] FOREIGN KEY([id_language])
REFERENCES [dbo].[Language] ([id])
GO
ALTER TABLE [dbo].[Solution] CHECK CONSTRAINT [FK_languagesolution]
GO
/****** Object:  ForeignKey [FK_problemsolution]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[Solution]  WITH CHECK ADD  CONSTRAINT [FK_problemsolution] FOREIGN KEY([id_problem])
REFERENCES [dbo].[Problem] ([Id])
GO
ALTER TABLE [dbo].[Solution] CHECK CONSTRAINT [FK_problemsolution]
GO
/****** Object:  ForeignKey [FK_usersolution]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[Solution]  WITH CHECK ADD  CONSTRAINT [FK_usersolution] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Solution] CHECK CONSTRAINT [FK_usersolution]
GO
/****** Object:  ForeignKey [FK_solutionsourceCode]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[SourceCode]  WITH CHECK ADD  CONSTRAINT [FK_solutionsourceCode] FOREIGN KEY([Id_solution])
REFERENCES [dbo].[Solution] ([id])
GO
ALTER TABLE [dbo].[SourceCode] CHECK CONSTRAINT [FK_solutionsourceCode]
GO
/****** Object:  ForeignKey [FK_UGAssignmentDOUser]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[UGAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UGAssignmentDOUser] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UGAssignment] CHECK CONSTRAINT [FK_UGAssignmentDOUser]
GO
/****** Object:  ForeignKey [FK_UGAssignmentDOUserGroupDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[UGAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UGAssignmentDOUserGroupDO] FOREIGN KEY([Id_UserGroup])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[UGAssignment] CHECK CONSTRAINT [FK_UGAssignmentDOUserGroupDO]
GO
/****** Object:  ForeignKey [FK_UPAssignmentDOPermissionDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[UPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UPAssignmentDOPermissionDO] FOREIGN KEY([Id_Permission])
REFERENCES [dbo].[Permission] ([id])
GO
ALTER TABLE [dbo].[UPAssignment] CHECK CONSTRAINT [FK_UPAssignmentDOPermissionDO]
GO
/****** Object:  ForeignKey [FK_UserUPAssignmentDO]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[UPAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UserUPAssignmentDO] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UPAssignment] CHECK CONSTRAINT [FK_UserUPAssignmentDO]
GO
/****** Object:  ForeignKey [FK_URAssignmentDORoleDo]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[URAssignment]  WITH CHECK ADD  CONSTRAINT [FK_URAssignmentDORoleDo] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[URAssignment] CHECK CONSTRAINT [FK_URAssignmentDORoleDo]
GO
/****** Object:  ForeignKey [FK_URAssignmentDOUser]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[URAssignment]  WITH CHECK ADD  CONSTRAINT [FK_URAssignmentDOUser] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[URAssignment] CHECK CONSTRAINT [FK_URAssignmentDOUser]
GO
/****** Object:  ForeignKey [FK_languageuser]    Script Date: 05/30/2016 11:19:31 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_languageuser] FOREIGN KEY([Id_language])
REFERENCES [dbo].[Language] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_languageuser]
GO
