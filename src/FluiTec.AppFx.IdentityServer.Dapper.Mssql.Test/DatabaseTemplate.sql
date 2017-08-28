USE AppFx
GO
/****** Object:  Table [AppFxIdentityServer.].[ApiResource]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[ApiResource](
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
/****** Object:  Table [AppFxIdentityServer.].[ApiResourceClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[ApiResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ApiResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [AppFxIdentityServer.].[ApiResourceScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[ApiResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ApiResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [AppFxIdentityServer.].[Client]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[Client](
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
/****** Object:  Table [AppFxIdentityServer.].[ClientClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[ClientClaim](
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
/****** Object:  Table [AppFxIdentityServer.].[ClientScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[ClientScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ClientScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [AppFxIdentityServer.].[IdentityGrant]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[IdentityGrant](
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
/****** Object:  Table [AppFxIdentityServer.].[IdentityResource]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[IdentityResource](
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
/****** Object:  Table [AppFxIdentityServer.].[IdentityResourceClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[IdentityResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_IdentityResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [AppFxIdentityServer.].[IdentityResourceScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[IdentityResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_IdentityResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [AppFxIdentityServer.].[Scope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[Scope](
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
/****** Object:  Table [AppFxIdentityServer.].[SigningCredential]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppFxIdentityServer.].[SigningCredential](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Issued] [datetime] NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SigningCredential] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityClient]    Script Date: 11.08.2017 13:39:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityClient] ON [AppFxIdentityServer.].[IdentityClient]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityClient_1]    Script Date: 11.08.2017 13:39:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityClient_1] ON [AppFxIdentityServer.].[IdentityClient]
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Grant]    Script Date: 11.08.2017 13:39:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Grant] ON [AppFxIdentityServer.].[IdentityGrant]
(
	[GrantKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AllowOfflineAccess]  DEFAULT ((1)) FOR [AllowOfflineAccess]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AllowRememberConsent]  DEFAULT ((1)) FOR [AllowRememberConsent]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AlwaysIncludeUserClaimsInIdToken]  DEFAULT ((0)) FOR [AlwaysIncludeUserClaimsInIdToken]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_EnableLocalLogin]  DEFAULT ((1)) FOR [EnableLocalLogin]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AbsoluteRefreshTokenLifetime]  DEFAULT ((2592000)) FOR [AbsoluteRefreshTokenLifetime]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AccessTokenLifetime]  DEFAULT ((3600)) FOR [AccessTokenLifetime]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AuthorizationCodeLifetime]  DEFAULT ((3600)) FOR [AuthorizationCodeLifetime]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_IdentityTokenLifetime]  DEFAULT ((300)) FOR [IdentityTokenLifetime]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_SlidingRefreshTokenLifetime]  DEFAULT ((1296000)) FOR [SlidingRefreshTokenLifetime]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_RefreshTokenExpiration]  DEFAULT ((0)) FOR [RefreshTokenExpiration]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_RefreshTokenUsage]  DEFAULT ((0)) FOR [RefreshTokenUsage]
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceClaim_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [AppFxIdentityServer.].[ApiResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceClaim] CHECK CONSTRAINT [FK_ApiResourceClaim_ApiResource]
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [AppFxIdentityServer.].[ApiResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_ApiResource]
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer.].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_Scope]
GO
ALTER TABLE [AppFxIdentityServer.].[ClientClaim]  WITH CHECK ADD  CONSTRAINT [FK_ClientClaim_Client] FOREIGN KEY([ClientId])
REFERENCES [AppFxIdentityServer.].[Client] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ClientClaim] CHECK CONSTRAINT [FK_ClientClaim_Client]
GO
ALTER TABLE [AppFxIdentityServer.].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Client] FOREIGN KEY([ClientId])
REFERENCES [AppFxIdentityServer.].[Client] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Client]
GO
ALTER TABLE [AppFxIdentityServer.].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer.].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Scope]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceClaim_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [AppFxIdentityServer.].[IdentityResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceClaim] CHECK CONSTRAINT [FK_IdentityResourceClaim_IdentityResource]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [AppFxIdentityServer.].[IdentityResource] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_IdentityResource]
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [AppFxIdentityServer.].[Scope] ([Id])
GO
ALTER TABLE [AppFxIdentityServer.].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_Scope]
GO
USE [master]
GO
ALTER DATABASE [CallRouting] SET  READ_WRITE 
GO