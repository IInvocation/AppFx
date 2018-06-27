#addin "Cake.FileHelpers"
#load "projects.cake"
#load "helpers.cake"

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
		UpdateNugetPackages(project, autoUpdatePrefix);
		NuGetRestore(project.ProjectFile);
		if (configuration == "Release")
		{
			IncreaseVersionNumber(project.ProjectFile);
		}
		BuildProject(project.ProjectFile);
		if (configuration == "Release")
		{
			CreateNugetPackage(project, configuration);
			PublishNugetPackageLocal(project, configuration, @"\\localhost\nuget");
		}
	}
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
