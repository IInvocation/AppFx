//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////
var conf = Argument("configuration", "Release");

// Define projects
var projects = new[] {
	new ProjectInfo // LocalizationProvider
	(
		Directory("../src/Localization/LocalizationProvider/src/DbLocalizationProvider.Abstractions/bin") + Directory(conf), 
		File("../src/Localization/LocalizationProvider/src/DbLocalizationProvider.Abstractions/DbLocalizationProvider.Abstractions.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/LocalizationProvider/src/DbLocalizationProvider/bin") + Directory(conf), 
		File("../src/Localization/LocalizationProvider/src/DbLocalizationProvider/DbLocalizationProvider.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Options
	(
		Directory("../src/Options/FluiTec.AppFx.Options/bin") + Directory(conf), 
		File("../src/Options/FluiTec.AppFx.Options/FluiTec.AppFx.Options.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Reflection
	(
		Directory("../src/Reflection/FluiTec.AppFx.Reflection/bin") + Directory(conf), 
		File("../src/Reflection/FluiTec.AppFx.Reflection/FluiTec.AppFx.Reflection.csproj"), 
		increaseVersion
	),
	new ProjectInfo // InversionOfControl
	(
		Directory("../src/Tooling/FluiTec.AppFx.InversionOfControl/bin") + Directory(conf), 
		File("../src/Tooling/FluiTec.AppFx.InversionOfControl/FluiTec.AppFx.InversionOfControl.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Tooling/FluiTec.AppFx.InversionOfControl.SimpleIoC/bin") + Directory(conf), 
		File("../src/Tooling/FluiTec.AppFx.InversionOfControl.SimpleIoC/FluiTec.AppFx.InversionOfControl.SimpleIoC.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Cryptography
	(
		Directory("../src/Cryptography/FluiTec.AppFx.Cryptography/bin") + Directory(conf), 
		File("../src/Cryptography/FluiTec.AppFx.Cryptography/FluiTec.AppFx.Cryptography.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Networking
	(
		Directory("../src/Networking/FluiTec.AppFx.Rest/bin") + Directory(conf), 
		File("../src/Networking/FluiTec.AppFx.Rest/FluiTec.AppFx.Rest.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Networking/FluiTec.AppFx.Mail/bin") + Directory(conf), 
		File("../src/Networking/FluiTec.AppFx.Mail/FluiTec.AppFx.Mail.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Data
	(
		Directory("../src/Data/FluiTec.AppFx.Data/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data/FluiTec.AppFx.Data.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Sql/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Sql/FluiTec.AppFx.Data.Sql.csproj"), 
		increaseVersion 
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dapper/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dapper/FluiTec.AppFx.Data.Dapper.csproj"), 
		increaseVersion
	)
	,
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dapper.Mssql/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dapper.Mssql/FluiTec.AppFx.Data.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dapper.Mysql/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dapper.Mysql/FluiTec.AppFx.Data.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dapper.Pgsql/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dapper.Pgsql/FluiTec.AppFx.Data.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dapper.SqLite/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dapper.SqLite/FluiTec.AppFx.Data.Dapper.SqLite.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.LiteDb/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.LiteDb/FluiTec.AppFx.Data.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Data/FluiTec.AppFx.Data.Dynamic/bin") + Directory(conf), 
		File("../src/Data/FluiTec.AppFx.Data.Dynamic/FluiTec.AppFx.Data.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Authentication
	(
		Directory("../src/Authentication/FluiTec.AppFx.OpenId/bin") + Directory(conf), 
		File("../src/Authentication/FluiTec.AppFx.OpenId/FluiTec.AppFx.OpenId.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authentication/FluiTec.AppFx.Authentication.Amazon/bin") + Directory(conf), 
		File("../src/Authentication/FluiTec.AppFx.Authentication.Amazon/FluiTec.AppFx.Authentication.Amazon.csproj"), 
		increaseVersion
	),
	new ProjectInfo // DataProtection
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection/FluiTec.AppFx.DataProtection.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.LiteDb/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.LiteDb/FluiTec.AppFx.DataProtection.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.Dapper/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.Dapper/FluiTec.AppFx.DataProtection.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.Mssql/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.Mssql/FluiTec.AppFx.DataProtection.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.Mysql/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.Mysql/FluiTec.AppFx.DataProtection.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.Pgsql/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.Pgsql/FluiTec.AppFx.DataProtection.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/DataProtection/FluiTec.AppFx.DataProtection.Dynamic/bin") + Directory(conf), 
		File("../src/DataProtection/FluiTec.AppFx.DataProtection.Dynamic/FluiTec.AppFx.DataProtection.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization/FluiTec.AppFx.Localization.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Localization
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization/FluiTec.AppFx.Localization.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.LiteDb/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.LiteDb/FluiTec.AppFx.Localization.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.Dapper/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.Dapper/FluiTec.AppFx.Localization.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.Mssql/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.Mssql/FluiTec.AppFx.Localization.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.Mysql/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.Mysql/FluiTec.AppFx.Localization.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.Pgsql/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.Pgsql/FluiTec.AppFx.Localization.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Localization/FluiTec.AppFx.Localization.Dynamic/bin") + Directory(conf), 
		File("../src/Localization/FluiTec.AppFx.Localization.Dynamic/FluiTec.AppFx.Localization.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Identity
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity/FluiTec.AppFx.Identity.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.LiteDb/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.LiteDb/FluiTec.AppFx.Identity.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.Dapper/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.Dapper/FluiTec.AppFx.Identity.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.Dapper.Mssql/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.Dapper.Mssql/FluiTec.AppFx.Identity.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.Dapper.Mysql/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.Dapper.Mysql/FluiTec.AppFx.Identity.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.Dapper.Pgsql/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.Dapper.Pgsql/FluiTec.AppFx.Identity.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Identity/FluiTec.AppFx.Identity.Dynamic/bin") + Directory(conf), 
		File("../src/Identity/FluiTec.AppFx.Identity.Dynamic/FluiTec.AppFx.Identity.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // IdentityServer
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer/FluiTec.AppFx.IdentityServer.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.LiteDb/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.LiteDb/FluiTec.AppFx.IdentityServer.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper/FluiTec.AppFx.IdentityServer.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mssql/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mssql/FluiTec.AppFx.IdentityServer.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mysql/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mysql/FluiTec.AppFx.IdentityServer.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Pgsql/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Pgsql/FluiTec.AppFx.IdentityServer.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dynamic/bin") + Directory(conf), 
		File("../src/IdentityServer/FluiTec.AppFx.IdentityServer.Dynamic/FluiTec.AppFx.IdentityServer.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Authorization.Activity
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity/FluiTec.AppFx.Authorization.Activity.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.LiteDb/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.LiteDb/FluiTec.AppFx.Authorization.Activity.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper/FluiTec.AppFx.Authorization.Activity.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dynamic/bin") + Directory(conf), 
		File("../src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dynamic/FluiTec.AppFx.Authorization.Activity.Dynamic.csproj"), 
		increaseVersion
	)
	,
	new ProjectInfo // AspNetCore
	(
		Directory("../src/AspNetCore/FluiTec.AppFx.AspNetCore/bin") + Directory(conf), 
		File("../src/AspNetCore/FluiTec.AppFx.AspNetCore/FluiTec.AppFx.AspNetCore.csproj"), 
		increaseVersion
	)
};