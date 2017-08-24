USE AppFx
GO
/****** Object:  Table [dbo].[ApiResource]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Enabled] [bit] NULL,
 CONSTRAINT [PK_ApiResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApiResourceClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ApiResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApiResourceScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ApiResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
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
/****** Object:  Table [dbo].[ClientClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientClaim](
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
/****** Object:  Table [dbo].[ClientScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_ClientScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityGrant]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityGrant](
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
/****** Object:  Table [dbo].[IdentityResource]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityResource](
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
/****** Object:  Table [dbo].[IdentityResourceClaim]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityResourceClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ClaimType] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_IdentityResourceClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityResourceScope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityResourceScope](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
 CONSTRAINT [PK_IdentityResourceScope] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scope]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scope](
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
/****** Object:  Table [dbo].[SigningCredential]    Script Date: 11.08.2017 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SigningCredential](
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
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityClient] ON [dbo].[IdentityClient]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityClient_1]    Script Date: 11.08.2017 13:39:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityClient_1] ON [dbo].[IdentityClient]
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Grant]    Script Date: 11.08.2017 13:39:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Grant] ON [dbo].[IdentityGrant]
(
	[GrantKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AllowOfflineAccess]  DEFAULT ((1)) FOR [AllowOfflineAccess]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AllowRememberConsent]  DEFAULT ((1)) FOR [AllowRememberConsent]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AlwaysIncludeUserClaimsInIdToken]  DEFAULT ((0)) FOR [AlwaysIncludeUserClaimsInIdToken]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_EnableLocalLogin]  DEFAULT ((1)) FOR [EnableLocalLogin]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AbsoluteRefreshTokenLifetime]  DEFAULT ((2592000)) FOR [AbsoluteRefreshTokenLifetime]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AccessTokenLifetime]  DEFAULT ((3600)) FOR [AccessTokenLifetime]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_AuthorizationCodeLifetime]  DEFAULT ((3600)) FOR [AuthorizationCodeLifetime]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_IdentityTokenLifetime]  DEFAULT ((300)) FOR [IdentityTokenLifetime]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_SlidingRefreshTokenLifetime]  DEFAULT ((1296000)) FOR [SlidingRefreshTokenLifetime]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_RefreshTokenExpiration]  DEFAULT ((0)) FOR [RefreshTokenExpiration]
GO
ALTER TABLE [dbo].[IdentityClient] ADD  CONSTRAINT [DF_IdentityClient_RefreshTokenUsage]  DEFAULT ((0)) FOR [RefreshTokenUsage]
GO
ALTER TABLE [dbo].[ApiResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceClaim_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [dbo].[ApiResource] ([Id])
GO
ALTER TABLE [dbo].[ApiResourceClaim] CHECK CONSTRAINT [FK_ApiResourceClaim_ApiResource]
GO
ALTER TABLE [dbo].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_ApiResource] FOREIGN KEY([ApiResourceId])
REFERENCES [dbo].[ApiResource] ([Id])
GO
ALTER TABLE [dbo].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_ApiResource]
GO
ALTER TABLE [dbo].[ApiResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_ApiResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [dbo].[Scope] ([Id])
GO
ALTER TABLE [dbo].[ApiResourceScope] CHECK CONSTRAINT [FK_ApiResourceScope_Scope]
GO
ALTER TABLE [dbo].[ClientClaim]  WITH CHECK ADD  CONSTRAINT [FK_ClientClaim_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientClaim] CHECK CONSTRAINT [FK_ClientClaim_Client]
GO
ALTER TABLE [dbo].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Client]
GO
ALTER TABLE [dbo].[ClientScope]  WITH CHECK ADD  CONSTRAINT [FK_ClientScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [dbo].[Scope] ([Id])
GO
ALTER TABLE [dbo].[ClientScope] CHECK CONSTRAINT [FK_ClientScope_Scope]
GO
ALTER TABLE [dbo].[IdentityResourceClaim]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceClaim_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [dbo].[IdentityResource] ([Id])
GO
ALTER TABLE [dbo].[IdentityResourceClaim] CHECK CONSTRAINT [FK_IdentityResourceClaim_IdentityResource]
GO
ALTER TABLE [dbo].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_IdentityResource] FOREIGN KEY([IdentityResourceId])
REFERENCES [dbo].[IdentityResource] ([Id])
GO
ALTER TABLE [dbo].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_IdentityResource]
GO
ALTER TABLE [dbo].[IdentityResourceScope]  WITH CHECK ADD  CONSTRAINT [FK_IdentityResourceScope_Scope] FOREIGN KEY([ScopeId])
REFERENCES [dbo].[Scope] ([Id])
GO
ALTER TABLE [dbo].[IdentityResourceScope] CHECK CONSTRAINT [FK_IdentityResourceScope_Scope]
GO
USE [master]
GO
ALTER DATABASE [CallRouting] SET  READ_WRITE 
GO