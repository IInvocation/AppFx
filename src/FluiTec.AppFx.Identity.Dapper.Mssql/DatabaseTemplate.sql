USE <YourDatabaseName>

GO
/****** Object:  Table [dbo].[IdentityClaim]    Script Date: 11.08.2017 13:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Type] [nvarchar](256) NOT NULL,
	[Value] [nvarchar](256) NULL,
 CONSTRAINT [PK_IdentityClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityRole]    Script Date: 11.08.2017 13:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[LoweredName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_IdentityRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUser]    Script Date: 11.08.2017 13:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
	[PasswordHash] [nvarchar](256) NULL,
	[SecurityStamp] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NOT NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[Phone] [nvarchar](256) NULL,
	[PhoneConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[LockedOutTill] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_IdentityUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserLogin]    Script Date: 11.08.2017 13:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](255) NOT NULL,
	[ProviderKey] [nvarchar](45) NOT NULL,
	[ProviderDisplayName] [nvarchar](255) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_IdentityUserLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserRole]    Script Date: 11.08.2017 13:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_IdentityUser]    Script Date: 11.08.2017 13:34:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUser] ON [dbo].[IdentityUser]
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityUser_1]    Script Date: 11.08.2017 13:34:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUser_1] ON [dbo].[IdentityUser]
(
	[LoweredUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityUserLogin]    Script Date: 11.08.2017 13:34:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUserLogin] ON [dbo].[IdentityUserLogin]
(
	[ProviderName] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IdentityUser] ADD  CONSTRAINT [DF_Identifier]  DEFAULT (newsequentialid()) FOR [Identifier]
GO
ALTER TABLE [dbo].[IdentityClaim]  WITH CHECK ADD  CONSTRAINT [FK_IdentityClaim_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([Id])
GO
ALTER TABLE [dbo].[IdentityClaim] CHECK CONSTRAINT [FK_IdentityClaim_IdentityUser]
GO
ALTER TABLE [dbo].[IdentityUserLogin]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogin_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([Identifier])
GO
ALTER TABLE [dbo].[IdentityUserLogin] CHECK CONSTRAINT [FK_IdentityUserLogin_IdentityUser]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole_IdentityRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[IdentityRole] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_IdentityUserRole_IdentityRole]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUser] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_IdentityUserRole_IdentityUser]
GO