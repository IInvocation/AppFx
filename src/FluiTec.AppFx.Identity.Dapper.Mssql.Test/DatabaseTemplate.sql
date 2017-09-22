USE [AppFx]
GO
CREATE SCHEMA [AppFxIdentity]
GO

/****** Object:  Table [AppFxIdentity].[Claim]    Script Date: 22.09.2017 13:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentity].[Claim](
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
/****** Object:  Table [AppFxIdentity].[Role]    Script Date: 22.09.2017 13:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentity].[Role](
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
/****** Object:  Table [AppFxIdentity].[User]    Script Date: 22.09.2017 13:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentity].[User](
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
/****** Object:  Table [AppFxIdentity].[UserLogin]    Script Date: 22.09.2017 13:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentity].[UserLogin](
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
/****** Object:  Table [AppFxIdentity].[UserRole]    Script Date: 22.09.2017 13:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentity].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [IX_IdentityUser]    Script Date: 22.09.2017 13:08:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUser] ON [AppFxIdentity].[User]
(
	[Identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityUser_1]    Script Date: 22.09.2017 13:08:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUser_1] ON [AppFxIdentity].[User]
(
	[LoweredUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityUserLogin]    Script Date: 22.09.2017 13:08:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityUserLogin] ON [AppFxIdentity].[UserLogin]
(
	[ProviderName] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO