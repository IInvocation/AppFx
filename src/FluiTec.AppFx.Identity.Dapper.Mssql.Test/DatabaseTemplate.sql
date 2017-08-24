USE [AppFx]
GO
/****** Object:  Schema [AppFxIdentity]    Script Date: 24.08.2017 11:52:52 ******/
CREATE SCHEMA [AppFxIdentity]
GO
/****** Object:  Table [AppFxIdentity].[Claim]    Script Date: 24.08.2017 11:52:52 ******/
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
/****** Object:  Table [AppFxIdentity].[Role]    Script Date: 24.08.2017 11:52:52 ******/
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
/****** Object:  Table [AppFxIdentity].[User]    Script Date: 24.08.2017 11:52:52 ******/
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
/****** Object:  Table [AppFxIdentity].[UserLogin]    Script Date: 24.08.2017 11:52:52 ******/
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
/****** Object:  Table [AppFxIdentity].[UserRole]    Script Date: 24.08.2017 11:52:52 ******/
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
ALTER TABLE [AppFxIdentity].[User] ADD  CONSTRAINT [DF_Identifier]  DEFAULT (newsequentialid()) FOR [Identifier]
GO
ALTER TABLE [AppFxIdentity].[Claim]  WITH CHECK ADD  CONSTRAINT [FK_IdentityClaim_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [AppFxIdentity].[User] ([Id])
GO
ALTER TABLE [AppFxIdentity].[Claim] CHECK CONSTRAINT [FK_IdentityClaim_IdentityUser]
GO
ALTER TABLE [AppFxIdentity].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogin_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [AppFxIdentity].[User] ([Identifier])
GO
ALTER TABLE [AppFxIdentity].[UserLogin] CHECK CONSTRAINT [FK_IdentityUserLogin_IdentityUser]
GO
ALTER TABLE [AppFxIdentity].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole_IdentityRole] FOREIGN KEY([RoleId])
REFERENCES [AppFxIdentity].[Role] ([Id])
GO
ALTER TABLE [AppFxIdentity].[UserRole] CHECK CONSTRAINT [FK_IdentityUserRole_IdentityRole]
GO
ALTER TABLE [AppFxIdentity].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole_IdentityUser] FOREIGN KEY([UserId])
REFERENCES [AppFxIdentity].[User] ([Id])
GO
ALTER TABLE [AppFxIdentity].[UserRole] CHECK CONSTRAINT [FK_IdentityUserRole_IdentityUser]
GO
