#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.FileHelpers"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var increaseVersion = configuration == "Release";

//////////////////////////////////////////////////////////////////////
// CONFIGURATION
//////////////////////////////////////////////////////////////////////

var autoUpdatePrefix = "FluiTec.AppFx";

//////////////////////////////////////////////////////////////////////
// CLASSES
//////////////////////////////////////////////////////////////////////

class ProjectInfo
{
	public ProjectInfo(ConvertableDirectoryPath _dir, ConvertableFilePath _file) : this(_dir, _file, true)
	{
	}
	
	public ProjectInfo(ConvertableDirectoryPath _dir, ConvertableFilePath _file, bool _increaseVersion, params string[] packages)
	{
		ProjectDirectory = _dir;
		ProjectFile = _file;
		IncreaseVersion = _increaseVersion;	
		Packages = packages.ToList();
	}
	
	public ConvertableDirectoryPath ProjectDirectory {get; set;}
	
	public ConvertableFilePath ProjectFile {get; set;}
	
	public bool IncreaseVersion {get; set;}
	
	public List<string> Packages {get; set;}
}

//////////////////////////////////////////////////////////////////////
// FUNCTIONS
//////////////////////////////////////////////////////////////////////

void IncreaseVersionNumber(ConvertableFilePath project)
{
	var version = XmlPeek(project, versionXPath);
	var split = version.Split('.');
	var major = split[0];
	var minor = split[1];
	var build = int.Parse(split[2]) + 1;
	XmlPoke(project, versionXPath, major + "." + minor + "." + build);
	Information("Updated version of project '" + project + "' to " + version); 
}

void BuildProject(ConvertableFilePath project)
{
	if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild(project, settings => settings.SetConfiguration(configuration).SetVerbosity(Verbosity.Minimal));
    }
    else
    {
      // Use XBuild
      XBuild(project, settings => settings.SetConfiguration(configuration));
    }
}

void UpdateNugetPackages(ProjectInfo project)
{
	Information("Adding packages for " + project.ProjectFile);
	foreach(var line in FileReadLines(project.ProjectFile))
	{
		var trimmed = line.Trim();
		if (!string.IsNullOrWhiteSpace(trimmed) && trimmed.StartsWith("<PackageReference"))
		{
			var startIndex = trimmed.IndexOf("Include=") + 9;
			var length = trimmed.IndexOf("Version=")-2-startIndex;
			var id = trimmed.Substring(startIndex, length);
			if (id.StartsWith(autoUpdatePrefix))
			{
				DotNetCoreTool(project.ProjectFile, "add package " + id);
			}
		}
	}
	foreach(var package in project.Packages)
	{
		DotNetCoreTool(project.ProjectFile, "add package " + package);
	}
}

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define projects
var projects = new[] {
	new ProjectInfo // Options
	(
		Directory("./src/Options/FluiTec.AppFx.Options/bin") + Directory(configuration), 
		File("./src/Options/FluiTec.AppFx.Options/FluiTec.AppFx.Options.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Reflection
	(
		Directory("./src/Reflection/FluiTec.AppFx.Reflection/bin") + Directory(configuration), 
		File("./src/Reflection/FluiTec.AppFx.Reflection/FluiTec.AppFx.Reflection.csproj"), 
		increaseVersion
	),
	new ProjectInfo // InversionOfControl
	(
		Directory("./src/Tooling/FluiTec.AppFx.InversionOfControl/bin") + Directory(configuration), 
		File("./src/Tooling/FluiTec.AppFx.InversionOfControl/FluiTec.AppFx.InversionOfControl.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Tooling/FluiTec.AppFx.InversionOfControl.SimpleIoC/bin") + Directory(configuration), 
		File("./src/Tooling/FluiTec.AppFx.InversionOfControl.SimpleIoC/FluiTec.AppFx.InversionOfControl.SimpleIoC.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Cryptography
	(
		Directory("./src/Cryptography/FluiTec.AppFx.Cryptography/bin") + Directory(configuration), 
		File("./src/Cryptography/FluiTec.AppFx.Cryptography/FluiTec.AppFx.Cryptography.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Networking
	(
		Directory("./src/Networking/FluiTec.AppFx.Rest/bin") + Directory(configuration), 
		File("./src/Networking/FluiTec.AppFx.Rest/FluiTec.AppFx.Rest.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Networking/FluiTec.AppFx.Mail/bin") + Directory(configuration), 
		File("./src/Networking/FluiTec.AppFx.Mail/FluiTec.AppFx.Mail.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Data
	(
		Directory("./src/Data/FluiTec.AppFx.Data/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data/FluiTec.AppFx.Data.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Sql/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Sql/FluiTec.AppFx.Data.Sql.csproj"), 
		increaseVersion 
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dapper/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dapper/FluiTec.AppFx.Data.Dapper.csproj"), 
		increaseVersion
	)
	,
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dapper.Mssql/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dapper.Mssql/FluiTec.AppFx.Data.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dapper.Mysql/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dapper.Mysql/FluiTec.AppFx.Data.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dapper.Pgsql/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dapper.Pgsql/FluiTec.AppFx.Data.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dapper.SqLite/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dapper.SqLite/FluiTec.AppFx.Data.Dapper.SqLite.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.LiteDb/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.LiteDb/FluiTec.AppFx.Data.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Data/FluiTec.AppFx.Data.Dynamic/bin") + Directory(configuration), 
		File("./src/Data/FluiTec.AppFx.Data.Dynamic/FluiTec.AppFx.Data.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Authentication
	(
		Directory("./src/Authentication/FluiTec.AppFx.OpenId/bin") + Directory(configuration), 
		File("./src/Authentication/FluiTec.AppFx.OpenId/FluiTec.AppFx.OpenId.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authentication/FluiTec.AppFx.Authentication.Amazon/bin") + Directory(configuration), 
		File("./src/Authentication/FluiTec.AppFx.Authentication.Amazon/FluiTec.AppFx.Authentication.Amazon.csproj"), 
		increaseVersion
	),
	new ProjectInfo // DataProtection
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection/FluiTec.AppFx.DataProtection.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.LiteDb/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.LiteDb/FluiTec.AppFx.DataProtection.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.Dapper/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.Dapper/FluiTec.AppFx.DataProtection.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.Mssql/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.Mssql/FluiTec.AppFx.DataProtection.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.Mysql/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.Mysql/FluiTec.AppFx.DataProtection.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.Pgsql/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.Pgsql/FluiTec.AppFx.DataProtection.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/DataProtection/FluiTec.AppFx.DataProtection.Dynamic/bin") + Directory(configuration), 
		File("./src/DataProtection/FluiTec.AppFx.DataProtection.Dynamic/FluiTec.AppFx.DataProtection.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization/FluiTec.AppFx.Localization.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Localization
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization/FluiTec.AppFx.Localization.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.LiteDb/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.LiteDb/FluiTec.AppFx.Localization.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.Dapper/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.Dapper/FluiTec.AppFx.Localization.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.Mssql/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.Mssql/FluiTec.AppFx.Localization.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.Mysql/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.Mysql/FluiTec.AppFx.Localization.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.Pgsql/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.Pgsql/FluiTec.AppFx.Localization.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Localization/FluiTec.AppFx.Localization.Dynamic/bin") + Directory(configuration), 
		File("./src/Localization/FluiTec.AppFx.Localization.Dynamic/FluiTec.AppFx.Localization.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Identity
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity/FluiTec.AppFx.Identity.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.LiteDb/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.LiteDb/FluiTec.AppFx.Identity.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.Dapper/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.Dapper/FluiTec.AppFx.Identity.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.Dapper.Mssql/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.Dapper.Mssql/FluiTec.AppFx.Identity.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.Dapper.Mysql/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.Dapper.Mysql/FluiTec.AppFx.Identity.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.Dapper.Pgsql/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.Dapper.Pgsql/FluiTec.AppFx.Identity.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Identity/FluiTec.AppFx.Identity.Dynamic/bin") + Directory(configuration), 
		File("./src/Identity/FluiTec.AppFx.Identity.Dynamic/FluiTec.AppFx.Identity.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // IdentityServer
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer/FluiTec.AppFx.IdentityServer.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.LiteDb/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.LiteDb/FluiTec.AppFx.IdentityServer.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper/FluiTec.AppFx.IdentityServer.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mssql/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mssql/FluiTec.AppFx.IdentityServer.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mysql/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Mysql/FluiTec.AppFx.IdentityServer.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Pgsql/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dapper.Pgsql/FluiTec.AppFx.IdentityServer.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dynamic/bin") + Directory(configuration), 
		File("./src/IdentityServer/FluiTec.AppFx.IdentityServer.Dynamic/FluiTec.AppFx.IdentityServer.Dynamic.csproj"), 
		increaseVersion
	),
	new ProjectInfo // Authorization.Activity
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity/FluiTec.AppFx.Authorization.Activity.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.LiteDb/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.LiteDb/FluiTec.AppFx.Authorization.Activity.LiteDb.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper/FluiTec.AppFx.Authorization.Activity.Dapper.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql/FluiTec.AppFx.Authorization.Activity.Dapper.Mssql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql/FluiTec.AppFx.Authorization.Activity.Dapper.Mysql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql/FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql.csproj"), 
		increaseVersion
	),
	new ProjectInfo
	(
		Directory("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dynamic/bin") + Directory(configuration), 
		File("./src/Authorization.Activity/FluiTec.AppFx.Authorization.Activity.Dynamic/FluiTec.AppFx.Authorization.Activity.Dynamic.csproj"), 
		increaseVersion
	)
	,
	new ProjectInfo // AspNetCore
	(
		Directory("./src/AspNetCore/FluiTec.AppFx.AspNetCore/bin") + Directory(configuration), 
		File("./src/AspNetCore/FluiTec.AppFx.AspNetCore/FluiTec.AppFx.AspNetCore.csproj"), 
		increaseVersion
	)
};

// Define constants
var versionXPath = "/Project/PropertyGroup/Version";
var packageXPath = "/Project/ItemGroup/PackageReference";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Info")
	.Does(() =>
{
	Information("Executing cake-script using configuration :'" + configuration + "'.");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("Info")
	.Does(() =>
{
	foreach(var project in projects)
	{
		CleanDirectory(project.ProjectDirectory);
		if (configuration == "Release")
		{
			UpdateNugetPackages(project);
		}
		NuGetRestore(project.ProjectFile);
		if (configuration == "Release")
		{
			IncreaseVersionNumber(project.ProjectFile);
		}
		BuildProject(project.ProjectFile);
	}
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
