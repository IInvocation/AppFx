SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";
CREATE TABLE `AppFxIdentity_Claim` (
  `Id` int(10) NOT NULL,
  `UserId` int(10) NOT NULL,
  `Type` varchar(256) COLLATE latin1_general_ci NOT NULL,
  `Value` varchar(256) COLLATE latin1_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentity_Role` (
  `Id` int(10) NOT NULL,
  `ApplicationId` int(10) NOT NULL,
  `Identifier` char(36) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(256) COLLATE latin1_general_ci NOT NULL,
  `LoweredName` varchar(256) COLLATE latin1_general_ci NOT NULL,
  `Description` varchar(256) COLLATE latin1_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentity_User` (
  `Id` int(10) NOT NULL,
  `ApplicationId` int(10) NOT NULL,
  `Identifier` char(36) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `LoweredUserName` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `MobileAlias` varchar(16) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `IsAnonymous` tinyint(1) NOT NULL,
  `LastActivityDate` datetime NOT NULL,
  `PasswordHash` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `SecurityStamp` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `Phone` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `PhoneConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` tinyint(1) NOT NULL,
  `LockedOutTill` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `AppFxIdentity_UserLogin` (
  `Id` int(10) NOT NULL,
  `ProviderName` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ProviderKey` varchar(45) COLLATE latin1_general_ci NOT NULL,
  `ProviderDisplayName` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `UserId` char(36) COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
CREATE TABLE `AppFxIdentity_UserRole` (
  `Id` int(10) NOT NULL,
  `UserId` int(10) NOT NULL,
  `RoleId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
ALTER TABLE `AppFxIdentity_Claim`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentity_Role`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentity_User`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentity_UserLogin`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentity_UserRole`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `AppFxIdentity_Claim`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
ALTER TABLE `AppFxIdentity_Role`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;
ALTER TABLE `AppFxIdentity_User`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=207;
ALTER TABLE `AppFxIdentity_UserLogin`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
ALTER TABLE `AppFxIdentity_UserRole`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;