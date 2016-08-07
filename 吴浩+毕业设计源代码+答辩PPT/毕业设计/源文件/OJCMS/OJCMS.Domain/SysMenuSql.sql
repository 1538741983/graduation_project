USE [OJCMS]
/****** Object:  Table [dbo].[User]    Script Date: 04/20/2016 18:58:07 ******/
GO
DELETE FROM [dbo].[User]
GO
INSERT [dbo].[User] ([Id], [Name], [UserName], [Pwd],[Ds]) VALUES (1, N'wuhao', N'wuhao', N'123',0)
/****** Object:  Table [dbo].[Menu]    Script Date: 04/20/2016 18:58:07 ******/
GO
DELETE FROM [dbo].[Menu]
GO
SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (1, N'01', N'OJ管理', NULL, NULL, 9, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (2, N'0101', N'用户管理', N'User/UserManager.aspx', NULL, 1, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (3, N'0102', N'问题管理', N'./temp/UserGroupManage.aspx', N'mainframe', 1, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (4, N'0103', N'新闻管理', N'News/NewsManager.aspx', NULL, 1, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (5, N'02', N'系统管理', NULL, NULL, 9, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (6, N'0201', N'菜单维护', N'Menu/MenuManager.aspx', NULL, 5, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (7, N'0202', N'权限管理', N'./temp/sys/RoleManage.aspx', N'mainframe', 5, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (8, N'0203', N'用户管理', N'User/UserManager.aspx', NULL, 5, NULL, 0, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Code], [Name], [NavigateUrl], [Target], [Id_perent], [InnerCode], [Ds], [Fg_sys], [Num]) VALUES (9, N'1', N'在线评测后台管理系统', NULL, NULL, 0, NULL, 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
