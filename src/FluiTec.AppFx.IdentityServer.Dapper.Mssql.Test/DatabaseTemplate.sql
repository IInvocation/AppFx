USE [AppFx]
GO
CREATE SCHEMA [AppFxIdentityServer]
GO

/****** Object:  Table [AppFxIdentityServer].[ApiResource]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[ApiResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_ApiResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[ApiResourceClaim]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[ApiResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ApiResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[ApiResourceScope]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[ApiResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ApiResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[Client]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Secret] [nvarchar](max) NOT NULL,
	[RedirectUri] [nvarchar](max) NULL,
	[PostLogoutUri] [nvarchar](max) NULL,
	[AllowOfflineAccess] [bit] NOT NULL,
	[GrantTypes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VisionClient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[ClientClaim]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[ClientClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
	[ClaimValue] [nvarchar](255) NULL,
 CONSTRAINT [PK_ClientClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[ClientScope]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[ClientScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ClientScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[Grant]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[Grant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GrantKey] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[SubjectId] [nvarchar](255) NOT NULL,
	[ClientId] [nvarchar](255) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[Expiration] [datetime] NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Grant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[IdentityResource]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[IdentityResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
	[Required] [bit] NOT NULL,
	[Emphasize] [bit] NOT NULL,
	[ShowInDiscoveryDocument] [bit] NOT NULL,
 CONSTRAINT [PK_IdentityResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[IdentityResourceClaim]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[IdentityResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_IdentityResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[IdentityResourceScope]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[IdentityResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_IdentityResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[Scope]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[Scope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Required] [bit] NOT NULL,
	[Emphasize] [bit] NOT NULL,
	[ShowInDiscoveryDocument] [bit] NOT NULL,
 CONSTRAINT [PK_Scope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppFxIdentityServer].[SigningCredential]    Script Date: 22.09.2017 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer].[SigningCredential](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Issued] [datetime] NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SigningCredential] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Index [IX_Grant]    Script Date: 22.09.2017 13:14:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Grant] ON [AppFxIdentityServer].[Grant]
(
	[GrantKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [AppFxIdentityServer].[ApiResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceClaim_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [AppFxIdentityServer].[ApiResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ApiResourceClaim] CHECK CONSTRAINT [FK_ApiResourceClaim_ApiResource]
GO
ALTER TABLE [AppFxIdentityServer].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [AppFxIdentityServer].[ApiResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_ApiResource]
GO
ALTER TABLE [AppFxIdentityServer].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_Scope]
GO
ALTER TABLE [AppFxIdentityServer].[ClientClaim]  WITH CHECK ADD  CONSTRAINT [FK_ClientClaim_Client] FOREIGN KEY([ClientId])
REFERENCES [AppFxIdentityServer].[Client] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ClientClaim] CHECK CONSTRAINT [FK_ClientClaim_Client]
GO
ALTER TABLE [AppFxIdentityServer].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Client] FOREIGN KEY([ClientId])
REFERENCES [AppFxIdentityServer].[Client] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Client]
GO
ALTER TABLE [AppFxIdentityServer].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Scope]
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceClaim_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [AppFxIdentityServer].[IdentityResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceClaim] CHECK CONSTRAINT [FK_IdentityResourceClaim_IdentityResource]
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [AppFxIdentityServer].[IdentityResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_IdentityResource]
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_Scope]
GO