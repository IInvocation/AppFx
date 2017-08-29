CREATE TABLE `AppFxIdentityServer_ApiResource` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `DisplayName` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Description` text COLLATE latin1_general_ci,
  `Enabled` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_ApiResourceClaim` (
  `Id` int(11) NOT NULL,
  `ApiResourceId` int(11) NOT NULL,
  `ClaimType` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_ApiResourceScope` (
  `Id` int(11) NOT NULL,
  `ApiResourceId` int(11) NOT NULL,
  `ScopeId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_Client` (
  `Id` int(11) NOT NULL,
  `ClientId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `Secret` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `RedirectUri` text COLLATE latin1_general_ci,
  `PostLogoutUri` text COLLATE latin1_general_ci,
  `AllowOfflineAccess` tinyint(1) NOT NULL,
  `GrantTypes` text COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_ClientClaim` (
  `Id` int(11) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `ClaimType` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ClaimValue` varchar(255) COLLATE latin1_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_ClientScope` (
  `Id` int(11) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `ScopeId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_Grant` (
  `Id` int(11) NOT NULL,
  `GrantKey` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Type` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `SubjectId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ClientId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `CreationTime` timestamp NULL DEFAULT NULL,
  `Expiration` timestamp NULL DEFAULT NULL,
  `Data` text COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_IdentityResource` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `DisplayName` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Description` text COLLATE latin1_general_ci,
  `Enabled` tinyint(1) NOT NULL,
  `Required` tinyint(1) NOT NULL,
  `Emphasize` tinyint(1) NOT NULL,
  `ShowInDiscoveryDocument` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

CREATE TABLE `AppFxIdentityServer_IdentityResourceClaim` (
  `Id` int(11) NOT NULL,
  `IdentityResourceId` int(11) NOT NULL,
  `ClaimType` varchar(255) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_IdentityResourceScope` (
  `Id` int(11) NOT NULL,
  `IdentityResourceId` int(11) NOT NULL,
  `ScopeId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_Scope` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `DisplayName` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Description` text COLLATE latin1_general_ci,
  `Required` tinyint(1) NOT NULL,
  `Emphasize` tinyint(1) NOT NULL,
  `ShowInDiscoveryDocument` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentityServer_SigningCredential` (
  `Id` int(11) NOT NULL,
  `Issued` timestamp NULL DEFAULT NULL,
  `Contents` text COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
ALTER TABLE `AppFxIdentityServer_ApiResource`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_ApiResourceClaim`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_ApiResourceScope`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_Client`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_ClientClaim`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_ClientScope`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_Grant`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_IdentityResource`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_IdentityResourceClaim`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_IdentityResourceScope`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_Scope`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_SigningCredential`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentityServer_ApiResource`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
ALTER TABLE `AppFxIdentityServer_ApiResourceClaim`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
ALTER TABLE `AppFxIdentityServer_ApiResourceScope`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
ALTER TABLE `AppFxIdentityServer_Client`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
ALTER TABLE `AppFxIdentityServer_ClientClaim`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
ALTER TABLE `AppFxIdentityServer_ClientScope`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
ALTER TABLE `AppFxIdentityServer_Grant`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
ALTER TABLE `AppFxIdentityServer_IdentityResource`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
ALTER TABLE `AppFxIdentityServer_IdentityResourceClaim`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
ALTER TABLE `AppFxIdentityServer_IdentityResourceScope`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
ALTER TABLE `AppFxIdentityServer_Scope`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;
ALTER TABLE `AppFxIdentityServer_SigningCredential`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;